using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<TodoItem?> GetByIdAsync(int id);
        Task AddAsync(TodoItem task);
        Task UpdateAsync(TodoItem task);
        Task DeleteAsync(int id);
    }
}