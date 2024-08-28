using Microsoft.EntityFrameworkCore;
using TunifyDb2.Data;
using TunifyDb2.Models;
using TunifyDb2.Repositories.Interfaces;

namespace TunifyDb2.Repositories.Services
{
    public class SongServices : ISong
    {
        private readonly TunifyDbContext _context;

        public SongServices(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<Songs> CreateSong(Songs song)
        {
            _context.songs.Add(song);
            await _context.SaveChangesAsync();
            return song;
        }

        public async Task DeleteSong(int id)
        {
            var getSong = await GetSongById(id);
            _context.songs.Remove(getSong);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Songs>> GetAllSongs()
        {
            var allSongs = await _context.songs.ToListAsync();
            return allSongs;
        }

        public async Task<Songs> GetSongById(int songId)
        {
            var specificSong = await _context.songs.FindAsync(songId);
            return specificSong;
        }

        public async Task<Songs> UpdateSong(int songId, Songs song)
        {
            var exsitingSong = await _context.songs.FindAsync(songId);
            exsitingSong = song;
            await _context.SaveChangesAsync();
            return song;
        }
    }
}
