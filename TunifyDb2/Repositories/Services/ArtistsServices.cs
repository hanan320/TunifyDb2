using Microsoft.EntityFrameworkCore;
using TunifyDb2.Data;
using TunifyDb2.Models;
using TunifyDb2.Repositories.Interfaces;

namespace TunifyDb2.Repositories.Services
{
    public class ArtistsServices :IArtists
    {
        private readonly TunifyDbContext _context;

        public ArtistsServices(TunifyDbContext context)
        {
            _context = context;
        }

        public async Task<Artists> CreateArtist(Artists artist)
        {
            _context.artists.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task DeleteArtists(int id)
        {
            var artist = await GetArtistById(id);
            if (artist != null)
            {
                _context.artists.Remove(artist);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Artist with ID {id} not found.");
            }
        }

        public async Task<List<Artists>> GetAllArtists()
        {
            return await _context.artists.ToListAsync();
        }

        public async Task<Artists> GetArtistById(int id)
        {
            var artist = await _context.artists.FindAsync(id);
            if (artist == null)
            {
                throw new KeyNotFoundException($"Artist with ID {id} not found.");
            }
            return artist;
        }

        public async Task<Artists> UpdateArtists(int id, Artists artist)
        {
            var exsitingArtist = await _context.artists.FindAsync(id);
            exsitingArtist = artist;
            await _context.SaveChangesAsync();
            return artist;
        }
    }
}
