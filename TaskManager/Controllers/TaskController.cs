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
}