using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem?> GetByIdAsync(int id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task AddAsync(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TodoItem todoItem)
        {
            _context.TodoItems.Update(todoItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            TodoItem? item = await _context.TodoItems.FindAsync(id);
            if (item is not null)
            {
                _context.TodoItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}