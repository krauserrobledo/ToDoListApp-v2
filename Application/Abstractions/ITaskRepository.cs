using Tasks = Domain.Models.Task;

namespace Application.Abstractions
{
    public interface ITaskRepository
    {
        // Get all tasks for a specific user
        Task<ICollection<Tasks>> GetTasksByUserAsync(string userId);
        Task<ICollection<Tasks>> GetTasksByUserWithDetailsAsync(string userId); // with categories and tags

        // Get tasks with related entities
        Task<ICollection<Tasks>> GetTasksWithCategoriesAndTagsAsync(string userId);
        Task<Tasks?> GetTaskWithDetailsAsync(string taskId);

        // Manage relationships
        Task AddTagToTaskAsync(string taskId, string tagId);
        Task RemoveTagFromTaskAsync(string taskId, string tagId);
        Task AddCategoryToTaskAsync(string taskId, string categoryId);
        Task RemoveCategoryFromTaskAsync(string taskId, string categoryId);

        // CRUD operations
        Task<Tasks?> GetTaskByIdAsync(string taskId);
        Task<Tasks> CreateTaskAsync(Tasks task);
        Task<Tasks?> UpdateTaskAsync(Tasks task);
        Task<bool> DeleteTaskAsync(string taskId);
    }
}