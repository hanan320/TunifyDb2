using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TunifyDb2.Data;
using TunifyDb2.Models;
using TunifyDb2.Repositories.Interfaces;

namespace TunifyDb2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISong _song;

        public SongsController(ISong context)
        {
            _song = context;
        }

        // GET: api/Songs
        [Route("/songs/GetAllSongs")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Songs>>> Getsongs()
        {
            return Ok(await _song.GetAllSongs());
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Songs>> GetSongs(int id)
        {
            var song = await _song.GetSongById(id);

            if (song == null)
            {
                return NotFound($"Song [{id}] not found.");
            }

            return Ok(song);
        }

        // PUT: api/Songs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongs(int id, Songs songs)
        {
            var updatedSong = await _song.UpdateSong(id, songs);
            //Check the user
            if (updatedSong == null)
            {
                return NotFound($"User [{id}] not found.");
            }
            return Ok(updatedSong);
        }

        // POST: api/Songs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Songs>> PostSongs(Songs songs)
        {
            var newSong = await _song.CreateSong(songs);
            return Ok(newSong);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSongs(int id)
        {
            //Check the user
            var song = await _song.GetSongById(id);
            if (song == null)
            {
                return NotFound($"Song [{id}] not found");
            }

            await _song.DeleteSong(id);
            return NoContent();
        }

      
    }
}
