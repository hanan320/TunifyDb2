using TunifyDb2.Models;

namespace TunifyDb2.Repositories.Interfaces
{
    public interface IArtists
    {
        Task<Artists> CreateArtist(Artists artist);
        Task<Artists> GetArtistById(int id);
        Task<List<Artists>> GetAllArtists();
        Task<Artists> UpdateArtists(int id, Artists artist);
        Task DeleteArtists(int id);
        Task AddSongToArtist(int artistId, int songId);
    }
}
