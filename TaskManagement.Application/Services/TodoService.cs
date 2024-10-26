using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Services
{
    public class TodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync() => await _todoRepository.GetAllAsync();

        public async Task<TodoItem?> GetByIdAsync(int id) => await _todoRepository.GetByIdAsync(id);

        public async Task AddAsync(TodoItem todoItem) => await _todoRepository.AddAsync(todoItem);

        public async Task UpdateAsync(TodoItem todoItem) => await _todoRepository.UpdateAsync(todoItem);

        public async Task DeleteAsync(int id) => await _todoRepository.DeleteAsync(id);
    }
}