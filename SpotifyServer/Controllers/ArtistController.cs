using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using SpotifyServer.db;

namespace SpotifyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly SpotyContext db;

        public ArtistController(SpotyContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<ArtistApi> Get()
        {
            return db.Artists.ToList().Select(s => (ArtistApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistApi>> Get(int id)
        {
            var artist = await db.Artists.FindAsync(id);
            if (artist == null)
                return NotFound();
            return Ok(artist);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ArtistApi value)
        {
            var newArtist = (Artist)value;
            db.Artists.Add(newArtist);
            await db.SaveChangesAsync();
            return Ok(newArtist.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ArtistApi value)
        {
            var oldArtist = await db.Artists.FindAsync(id);
            if (oldArtist == null)
                return NotFound();
            db.Entry(oldArtist).CurrentValues.SetValues(value);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldArtist = await db.Artists.FindAsync(id);
            if (oldArtist == null)
                return NotFound();
            db.Artists.Remove(oldArtist);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
