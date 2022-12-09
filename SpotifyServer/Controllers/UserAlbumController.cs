using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using SpotifyServer.db;

namespace SpotifyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAlbumController : ControllerBase
    {
        private readonly SpotyContext db;

        public UserAlbumController(SpotyContext db)
        {
            this.db = db;

        }

        [HttpGet]
        public IEnumerable<UserAlbumApi> Get()
        {
            return db.UserAlbums.ToList().Select(s => (UserAlbumApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserAlbumApi>> Get(int id)
        {
            var userAlbum = await db.UserAlbums.FindAsync(id);
            if (userAlbum == null)
                return NotFound();
            return Ok(userAlbum);
        }



        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] UserAlbumApi value)
        {
            var newUserAlbum = (UserAlbum)value;
            db.UserAlbums.Add(newUserAlbum);
            await db.SaveChangesAsync();
            return Ok(newUserAlbum.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserAlbumApi value)
        {
            var oldUserAlbum = await db.UserAlbums.FindAsync(id);
            if (oldUserAlbum == null)
                return NotFound();
            db.Entry(oldUserAlbum).CurrentValues.SetValues(value);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldUserAlbum = await db.UserAlbums.FindAsync(id);
            if (oldUserAlbum == null)
                return NotFound();
            db.UserAlbums.Remove(oldUserAlbum);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
