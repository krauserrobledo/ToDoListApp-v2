using Domain.Models;

namespace Application.Abstractions
{
    public interface ICategoryRepository
    {
        // Get all Categories with related entities
        Task<ICollection<Category>> GetCategoriesByUser(string userId);
        Task<Category?> GetCategoryById(string categoryId);
        Task<Category?> GetCategoryByName(string name, string userId);
        Task<bool> CategoryExists(string categoryId);
        Task<bool> CategoryNameExists(string name, string userId);

        // CRUD operations
        Task<Category> CreateCategory(Category category);
        Task<Category?> UpdateCategory(Category category);
        Task<bool> DeleteCategory(string categoryId);
    }
}
