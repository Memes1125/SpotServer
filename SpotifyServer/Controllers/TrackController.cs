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
            var albumTracks = db.AlbumTracks.ToList();
            var artistsTraks = db.ArtistsTraks.ToList();
            var likesTracks = db.LikesTracks.ToList();
            var trackHistories = db.TrackHistories.ToList();
            return db.Tracks.ToList().
                 Select(s =>
                 {
                     var result = (TrackApi)s;
                     result.TrackHistories = trackHistories.Where(a => a.IdTrack == s.Id).Select(a => (TrackHistoryApi)a);
                     result.AlbumTracks = albumTracks.Where(a => a.IdTrack == s.Id).Select(a => (AlbumTrackApi)a);
                     result.ArtistsTraks = artistsTraks.Where(a => a.IdTrack == s.Id).Select(a => (ArtistsTrakApi)a);
                     result.LikesTracks = likesTracks.Where(a => a.IdTrack == s.Id).Select(a => (LikesTrackApi)a);
                     return result;
                 });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrackApi>> Get(int id)
        {
            var track = await db.Tracks.FindAsync(id);
            if (track == null)
                return NotFound();
            var result = (TrackApi)track;
            result.TrackHistories = db.TrackHistories.Where(s => s.IdTrack == id).Select(a => (TrackHistoryApi)a);
            result.LikesTracks = db.LikesTracks.Where(a => a.IdTrack == id).Select(a => (LikesTrackApi)a);
            result.ArtistsTraks = db.ArtistsTraks.Where(a => a.IdTrack == id).Select(a => (ArtistsTrakApi)a);
            result.AlbumTracks = db.AlbumTracks.Where(a => a.IdTrack == id).Select(a => (AlbumTrackApi)a);
            return Ok(track);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] TrackApi value)
        {
            var newTrack = (Track)value;
            db.Tracks.Add(newTrack);
            var trackHistories = value.TrackHistories.Select(s => (TrackHistory)s);
            await db.TrackHistories.AddRangeAsync(trackHistories);
            var likesTracks = value.LikesTracks.Select(s => (LikesTrack)s);
            await db.LikesTracks.AddRangeAsync(likesTracks);
            var artistsTraks = value.ArtistsTraks.Select(s => (ArtistsTrak)s);
            await db.ArtistsTraks.AddRangeAsync(artistsTraks);
            var albumTracks = value.AlbumTracks.Select(s => (AlbumTrack)s);
            await db.AlbumTracks.AddRangeAsync(albumTracks);
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
