using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using SpotifyServer.db;

namespace SpotifyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsTrakController : ControllerBase
    {
        private readonly SpotyContext db;

        public ArtistsTrakController(SpotyContext db)
        {
            this.db = db;

        }

        [HttpGet]
        public IEnumerable<ArtistsTrakApi> Get()
        {
            return db.ArtistsTraks.ToList().Select(s => (ArtistsTrakApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistsTrakApi>> Get(int id)
        {
            var artistsTrak = await db.ArtistsTraks.FindAsync(id);
            if (artistsTrak == null)
                return NotFound();
            return Ok(artistsTrak);
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ArtistsTrakApi value)
        {
            var newArtistsTrak = (ArtistsTrak)value;
            db.ArtistsTraks.Add(newArtistsTrak);
            await db.SaveChangesAsync();
            return Ok(newArtistsTrak.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ArtistsTrakApi value)
        {
            var oldArtistsTrak = await db.ArtistsTraks.FindAsync(id);
            if (oldArtistsTrak == null)
                return NotFound();
            db.Entry(oldArtistsTrak).CurrentValues.SetValues(value);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldArtistsTrak = await db.ArtistsTraks.FindAsync(id);
            if (oldArtistsTrak == null)
                return NotFound();
            db.ArtistsTraks.Remove(oldArtistsTrak);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
