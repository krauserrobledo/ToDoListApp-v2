using Domain.Models;
using Task = System.Threading.Tasks.Task;

namespace Application.Abstractions
{
    public interface IUserRepository
    {
        // Basic CRUD operations
        Task<User?> GetByIdAsync(string userId);
        Task<User?> GetByEmailAsync(string email);
        Task<bool> ExistsAsync(string userId);
        Task<User> CreateAsync(User user);

        // Additional methods for user-related operations
        Task<ICollection<User>> GetUsersWithTasksAsync();
        Task<int> GetUserTaskCountAsync(string userId);
    }
}
