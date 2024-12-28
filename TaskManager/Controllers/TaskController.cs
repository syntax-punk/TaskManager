using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Db;
using TaskManager.Models;

namespace TaskManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController(TaskContext context) : ControllerBase
{
    private readonly TaskContext _context = context;
    
    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        var tasks = await _context.TaskItems.ToListAsync();

        if (tasks.Count == 0)
            return NotFound();
        
        return Ok(tasks);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTaskById(Guid id)
    {
        var task = await _context.TaskItems.FindAsync(id);

        if (task == null)
            return NotFound();
        
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody]RequestTaskItem requestTaskItem)
    {
        var task = new TaskItemDto
        {
            Id = Guid.NewGuid(),
            Name = requestTaskItem.Name,
            Description = requestTaskItem.Description,
            IsCompleted = requestTaskItem.IsCompleted,
            CreatedAt = DateTime.Now,
            DueDate = requestTaskItem.DueDate
        };

        await _context.TaskItems.AddAsync(task);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
    }
}