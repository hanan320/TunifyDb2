using TunifyDb2.Models;

namespace TunifyDb2.Repositories.Interfaces
{
    public interface IUser
    {
        Task<User> CreateUser(User user);
        Task<User> GetUserById(int id);
        Task<List<User>> GetAllUsers();
        Task<User> UpdateUser(int id, User user);
        Task DeleteUser(int id);
    }
}
