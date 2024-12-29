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
            return NotFound("Sorry, we couldn't find any tasks");
        
        return Ok(tasks);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTaskById(Guid id)
    {
        var task = await _context.TaskItems.FindAsync(id);

        if (task == null)
            return NotFound("Sorry, we couldn't find the task you were looking for");
        
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody]RequestTaskItem requestTaskItem)
    {
        var task = new TaskItemDto
        {
            Name = requestTaskItem.Name,
            Description = requestTaskItem.Description,
            IsCompleted = requestTaskItem.IsCompleted,
            CreatedAt = DateTime.Now,
            DueDate = requestTaskItem.DueDate
        };

        await _context.TaskItems.AddAsync(task);
        
        var result = await _context.SaveChangesAsync() > 0;
        
        if (!result)
            return BadRequest("We had an issue creating the task");

        return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateTask(Guid id, [FromBody]RequestTaskItem requestTaskItem)
    {
        var task = await _context.TaskItems.FindAsync(id);

        if (task == null)
            return NotFound();
        
        task.Name = requestTaskItem.Name;
        task.Description = requestTaskItem.Description;
        task.IsCompleted = requestTaskItem.IsCompleted;

        var result = await _context.SaveChangesAsync() > 0;
        
        if (!result)
            return BadRequest($"We had an issue updating the task: {id}");

        return Ok(task);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        var task = await _context.TaskItems.FindAsync(id);
        
        if (task == null)
            return NotFound("Sorry, we couldn't find the task you were looking for");

        _context.TaskItems.Remove(task);
        
        var result = await _context.SaveChangesAsync() > 0;
        
        if (!result)
            return BadRequest($"We had an issue deleting the task: {id}");
        
        return Ok();
    }
}