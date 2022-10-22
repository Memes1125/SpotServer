using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using SpotifyServer.db;

namespace SpotifyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SpotyContext db;

        public UserController(SpotyContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<UserApi> Get()
        {
            var userAlbum = db.UserAlbums.ToList();
            var trackHistories = db.TrackHistories.ToList();
            return db.Users.ToList().
                Select(s =>
                {
                    var result = (UserApi)s;
                    result.TrackHistories = trackHistories.Where(a => a.IdUser == s.Id).Select(a => (TrackHistoryApi)a);
                    result.UserAlbums = userAlbum.Where(a => a.IdUser == s.Id).Select(a => (UserAlbumApi)a);
                    return result;
                });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserApi>> Get(int id)
        {
            var user = await db.Users.FindAsync(id);
            if (user == null)
                return NotFound();
            var result = (UserApi)user;
            result.TrackHistories = db.TrackHistories.Where(s => s.IdUser == id).Select(a => (TrackHistoryApi)a);
            result.UserAlbums = db.UserAlbums.Where(a => a.IdUser == id).Select(a => (UserAlbumApi)a);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] UserApi value)
        {
            var newUser = (User)value;
            db.Users.Add(newUser);
            await db.SaveChangesAsync();
            var trackHistories = value.TrackHistories.Select(s => (TrackHistory)s);
            await db.TrackHistories.AddRangeAsync(trackHistories);
            var userAlbum = value.UserAlbums.Select(s => (UserAlbum)s);
            await db.UserAlbums.AddRangeAsync(userAlbum);
            await db.SaveChangesAsync();
            return Ok(newUser.Id);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserApi value)
        {
            var oldUser = await db.Users.FindAsync(id);
            if (oldUser == null)
                return NotFound();
            db.Entry(oldUser).CurrentValues.SetValues(value);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldUser = await db.Users.FindAsync(id);
            if (oldUser == null)
                return NotFound();
            db.Users.Remove(oldUser);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
