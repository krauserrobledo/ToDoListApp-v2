using Domain.Models;

namespace Application.Abstractions
{
    public interface ISubTaskRepository
    {
        // Get all Categories with related entities
        Task<ICollection<SubTask>> GetAllSubTasksByTask(string taskId);
        Task<SubTask?> GetSubTaskById(string subTaskId);

        // CRUD operations
        Task<SubTask> CreateSubTask(SubTask subTask);
        Task<SubTask?> UpdateSubTask(SubTask subTask);
        Task<bool> DeleteSubTask(string id);
    }
}
