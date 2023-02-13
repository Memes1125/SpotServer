using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using SpotifyServer.db;

namespace SpotifyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackHistoryController : ControllerBase
    {
        private readonly SpotyContext db;

        public TrackHistoryController(SpotyContext db)
        {
            this.db = db;

        }

        [HttpGet]
        public IEnumerable<TrackHistoryApi> Get()
        {
            return db.TrackHistories.ToList().Select(s => (TrackHistoryApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrackHistoryApi>> Get(int id)
        {
            var trackHistory = await db.TrackHistories.FindAsync(id);
            if (trackHistory == null)
                return NotFound();
            return Ok(trackHistory);
        }



        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] TrackHistoryApi value)
        {
            var newTrackHistory = (TrackHistory)value;
            db.TrackHistories.Add(newTrackHistory);
            await db.SaveChangesAsync();
            return Ok(newTrackHistory.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TrackHistoryApi value)
        {
            var oldTrackHistory = await db.TrackHistories.FindAsync(id);
            if (oldTrackHistory == null)
                return NotFound();
            db.Entry(oldTrackHistory).CurrentValues.SetValues(value);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldTrackHistory = await db.TrackHistories.FindAsync(id);
            if (oldTrackHistory == null)
                return NotFound();
            db.TrackHistories.Remove(oldTrackHistory);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
