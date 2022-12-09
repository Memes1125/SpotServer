using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using SpotifyServer.db;

namespace SpotifyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsArtistController : ControllerBase
    {
        private readonly SpotyContext db;

        public AlbumsArtistController(SpotyContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<AlbumsArtistApi> Get()
        {
            return db.AlbumsArtists.ToList().Select(s => (AlbumsArtistApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumsArtistApi>> Get(int id)
        {
            var albumsArtist = await db.AlbumsArtists.FindAsync(id);
            if (albumsArtist == null)
                return NotFound();
            return Ok(albumsArtist);
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] AlbumsArtistApi value)
        {
            var newAlbumsArtist = (AlbumsArtist)value;
            db.AlbumsArtists.Add(newAlbumsArtist);
            await db.SaveChangesAsync();
            return Ok(newAlbumsArtist.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AlbumsArtistApi value)
        {
            var oldAlbumsArtist = await db.AlbumsArtists.FindAsync(id);
            if (oldAlbumsArtist == null)
                return NotFound();
            db.Entry(oldAlbumsArtist).CurrentValues.SetValues(value);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldAlbumsArtist = await db.AlbumsArtists.FindAsync(id);
            if (oldAlbumsArtist == null)
                return NotFound();
            db.AlbumsArtists.Remove(oldAlbumsArtist);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
