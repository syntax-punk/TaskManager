using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TaskManager.Models;

namespace TaskManager.Db;

public class TaskContext(DbContextOptions<TaskContext> options) : DbContext(options)
{
    public DbSet<TaskItemDto> TaskItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // seed a single task
        modelBuilder.Entity<TaskItemDto>().HasData(
            new 
            {
                Id = Guid.NewGuid(),
                Name = "Test task",
                Description = "This is a dummy task",
                IsCompleted = false,
                CreatedAt = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7)
            }
        );
    }
}