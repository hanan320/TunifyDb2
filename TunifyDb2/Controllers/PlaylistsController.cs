using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TunifyDb2.Data;
using TunifyDb2.Models;

namespace TunifyDb2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly TunifyDbContext _context;

        public PlaylistsController(TunifyDbContext context)
        {
            _context = context;
        }

        // GET: api/Playlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlists>>> Getplaylists()
        {
          if (_context.playlists == null)
          {
              return NotFound();
          }
            return await _context.playlists.ToListAsync();
        }

        // GET: api/Playlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Playlists>> GetPlaylists(int id)
        {
          if (_context.playlists == null)
          {
              return NotFound();
          }
            var playlists = await _context.playlists.FindAsync(id);

            if (playlists == null)
            {
                return NotFound();
            }

            return playlists;
        }

        // PUT: api/Playlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylists(int id, Playlists playlists)
        {
            if (id != playlists.PlaylistsId)
            {
                return BadRequest();
            }

            _context.Entry(playlists).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Playlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Playlists>> PostPlaylists(Playlists playlists)
        {
          if (_context.playlists == null)
          {
              return Problem("Entity set 'TunifyDbContext.playlists'  is null.");
          }
            _context.playlists.Add(playlists);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaylists", new { id = playlists.PlaylistsId }, playlists);
        }

        // DELETE: api/Playlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylists(int id)
        {
            if (_context.playlists == null)
            {
                return NotFound();
            }
            var playlists = await _context.playlists.FindAsync(id);
            if (playlists == null)
            {
                return NotFound();
            }

            _context.playlists.Remove(playlists);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlaylistsExists(int id)
        {
            return (_context.playlists?.Any(e => e.PlaylistsId == id)).GetValueOrDefault();
        }
    }
}
