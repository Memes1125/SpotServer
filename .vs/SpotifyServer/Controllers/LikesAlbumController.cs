using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using SpotifyServer.db;

namespace SpotifyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesAlbumController : ControllerBase
    {
        private readonly SpotyContext db;

        public LikesAlbumController(SpotyContext db)
        {
            this.db = db;

        }

        [HttpGet]
        public IEnumerable<LikesAlbumApi> Get()
        {
            return db.LikesAlbums.ToList().Select(s => (LikesAlbumApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LikesAlbumApi>> Get(int id)
        {
            var likesAlbum = await db.LikesAlbums.FindAsync(id);
            if (likesAlbum == null)
                return NotFound();
            return Ok(likesAlbum);
        }



        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] LikesAlbumApi value)
        {
            var newLikesAlbum = (LikesAlbum)value;
            db.LikesAlbums.Add(newLikesAlbum);
            await db.SaveChangesAsync();
            return Ok(newLikesAlbum.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] LikesAlbumApi value)
        {
            var oldLikesAlbum = await db.LikesAlbums.FindAsync(id);
            if (oldLikesAlbum == null)
                return NotFound();
            db.Entry(oldLikesAlbum).CurrentValues.SetValues(value);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldLikesAlbum = await db.LikesAlbums.FindAsync(id);
            if (oldLikesAlbum == null)
                return NotFound();
            db.LikesAlbums.Remove(oldLikesAlbum);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
