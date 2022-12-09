using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using SpotifyServer.db;

namespace SpotifyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesTrackController : ControllerBase
    {
        private readonly SpotyContext db;

        public LikesTrackController(SpotyContext db)
        {
            this.db = db;

        }

        [HttpGet]
        public IEnumerable<LikesTrackApi> Get()
        {
            return db.LikesTracks.ToList().Select(s => (LikesTrackApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LikesTrackApi>> Get(int id)
        {
            var likesTrack = await db.LikesTracks.FindAsync(id);
            if (likesTrack == null)
                return NotFound();
            return Ok(likesTrack);
        }



        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] LikesTrackApi value)
        {
            var newLikesTrack = (LikesTrack)value;
            db.LikesTracks.Add(newLikesTrack);
            await db.SaveChangesAsync();
            return Ok(newLikesTrack.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] LikesTrackApi value)
        {
            var oldLikesTrack = await db.LikesTracks.FindAsync(id);
            if (oldLikesTrack == null)
                return NotFound();
            db.Entry(oldLikesTrack).CurrentValues.SetValues(value);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldLikesTrack = await db.LikesTracks.FindAsync(id);
            if (oldLikesTrack == null)
                return NotFound();
            db.LikesTracks.Remove(oldLikesTrack);
            await db.SaveChangesAsync();
            return Ok();
        }

    }
}
