using Domain.Abstractions;
using Data.Tools;
using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Data.Repositories
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Category> CreateCategory(Category category)
        {
            // Validate input using LINQ
            var existingCategory = await _context.Categories
                 .FirstOrDefaultAsync(c => c.Name == category.Name && c.UserId == category.UserId);
               if (existingCategory != null)
                 {
                 throw new InvalidOperationException("A category with the same name already exists for this user.");
            }
            // Generate a new GUID for the ID if not provided
            if (string.IsNullOrEmpty(category.Id) || string
                .IsNullOrWhiteSpace(category.Id))
                category.Id = Guid
                    .NewGuid()
                    .ToString();
            // Add to DbContext and save changes
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;

        }
        public async Task<bool> CategoryExists(string categoryId)
        {
            // Validate input and check existance using LINQ
            return await _context.Categories
                .AnyAsync(c => c.Id == categoryId);

        }

        public async Task<bool> CategoryNameExists(string name, string userId)
        {
            // Validate input and check existance using LINQ
            return await _context.Categories
                .AnyAsync(c => c.Name == name && c.UserId == userId);
        }

        public async Task<ICollection<Category>> GetCategoriesByUser(string userId)
        {
            // Validate input and retrieve using LINQ
            return await _context.Categories
                .Where(c => c.UserId == userId)
                .OrderByDescending(c => c.Id)
                .ToListAsync();
        }

        public async Task<Category?> GetCategoryByTaskId(string taskId, string userId)
        {
            // Validate input and retrieve using LINQ
            return await _context.Categories
                .Where(c => c.UserId == userId)
                .Join(_context.TaskCategories,
                      c => c.Id,
                      tc => tc.CategoryId,
                      (c, tc) => new { Category = c, TaskCategory = tc })
                .Where(joined => joined.TaskCategory.TaskId == taskId)
                .Select(joined => joined.Category)
                .FirstOrDefaultAsync();
        }

        public async Task<Category?> GetCategoryById(string categoryId)
        {
            // Validate input and retrieve using LINQ
            return await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        public async Task<Category?> UpdateCategory(Category category)
        {
            // Validate input using LINQ
            var existingCategory = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == category.Id);
            if (existingCategory == null)
                return null;
            // Update properties
            existingCategory.Name = category.Name?? existingCategory.Name;
            existingCategory.Color = category.Color ?? existingCategory.Color;
            // Update in DbContext and save changes
            await _context.SaveChangesAsync();
            return existingCategory;

        }

        public async Task<bool> DeleteCategory(string categoryId)
        {
            // Validate input using LINQ
            var categoryExist = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == categoryId);
            // Delete and save if exists
            if (categoryExist != null) 
            {
                _context.Categories.Remove(categoryExist);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
