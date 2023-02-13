using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using SpotifyServer.db;

namespace SpotifyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly SpotyContext db;

        public TrackController(SpotyContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<TrackApi> Get()
        {
            return db.Tracks.ToList().Select(s =>(TrackApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrackApi>> Get(int id)
        {
            var track = await db.Tracks.FindAsync(id);
            if (track == null)
                return NotFound();
            return Ok(track);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] TrackApi value)
        {
            var newTrack = (Track)value;
            db.Tracks.Add(newTrack);
            await db.SaveChangesAsync();
            return Ok(newTrack.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TrackApi value)
        {
            var oldTrack = await db.Tracks.FindAsync(id);
            if (oldTrack == null)
                return NotFound();
            db.Entry(oldTrack).CurrentValues.SetValues(value);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldTrack = await db.Tracks.FindAsync(id);
            if (oldTrack == null)
                return NotFound();
            db.Tracks.Remove(oldTrack);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
