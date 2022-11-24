using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using SpotifyServer.db;

namespace SpotifyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumTrackController : ControllerBase
    {
        private readonly SpotyContext db;

        public AlbumTrackController(SpotyContext db)
        {
            this.db = db;

        }

        [HttpGet]
        public IEnumerable<AlbumTrackApi> Get()
        {
            return db.AlbumTracks.ToList().Select(s => (AlbumTrackApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumTrackApi>> Get(int id)
        {
            var albumTrack = await db.AlbumTracks.FindAsync(id);
            if (albumTrack == null)
                return NotFound();
            return Ok(albumTrack);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] AlbumTrackApi value)
        {
            var newAlbumTrack = (AlbumTrack)value;
            db.AlbumTracks.Add(newAlbumTrack);
            await db.SaveChangesAsync();
            return Ok(newAlbumTrack.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AlbumTrackApi value)
        {
            var oldAlbumTrack = await db.AlbumTracks.FindAsync(id);
            if (oldAlbumTrack == null)
                return NotFound();
            db.Entry(oldAlbumTrack).CurrentValues.SetValues(value);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldAlbumTrack = await db.AlbumTracks.FindAsync(id);
            if (oldAlbumTrack == null)
                return NotFound();
            db.AlbumTracks.Remove(oldAlbumTrack);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
