using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsApi;
using SpotifyServer.db;
using System.ComponentModel;
using Newtonsoft.Json;

namespace SpotifyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AlbumController : ControllerBase
    {
        private readonly SpotyContext db;

        public AlbumController(SpotyContext db)
        {
            this.db = db;
            
        }

        [HttpGet]
        public IEnumerable<AlbumApi> Get()
        {
            return db.Albums.ToList().Select(s =>(AlbumApi)s);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumApi>> Get(int id)
        {
            var album = await db.Albums.FindAsync(id);
            if (album == null)
                return NotFound();
            return Ok(album);
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] AlbumApi album)
        {
            var newAlbum = (Album)album;
            db.Albums.Add(newAlbum);
            await db.SaveChangesAsync();
            return Ok(newAlbum.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AlbumApi value)
        {
            var oldAlbum = await db.Albums.FindAsync(id);
            if (oldAlbum == null)
                return NotFound();
            db.Entry(oldAlbum).CurrentValues.SetValues(value);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var oldAlbum = await db.Albums.FindAsync(id);
            if (oldAlbum == null)
                return NotFound();
            db.Albums.Remove(oldAlbum);
            await db.SaveChangesAsync();
            return Ok();
        }

    }
}
