using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.Entities;
using TaskManagement.Application.Services;

namespace TaskManagement.API.Controllers
{
    [Route("api/todo-item")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodoItemsController(TodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("get-all")]
        public async Task<IEnumerable<TodoItem>> GetAll() => await _todoService.GetAll();

        [HttpGet("get-byid/{id}")]
        public async Task<ActionResult<TodoItem>> GetById(int id)
        {
            TodoItem? todoItem = await _todoService.GetById(id);
            if (todoItem is null) return NotFound();
            return Ok(todoItem);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(TodoItem todoItem)
        {
            await _todoService.Add(todoItem);
            return CreatedAtAction(nameof(GetById), new { id = todoItem.Id }, todoItem);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, TodoItem todoItem)
        {
            if(id != todoItem.Id) return BadRequest();
            await _todoService.Update(todoItem);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _todoService.Delete(id);
            return NoContent();
        }
    }
}