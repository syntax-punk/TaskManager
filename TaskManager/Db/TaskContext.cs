using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Db;

public class TaskContext(DbContextOptions<TaskContext> options) : DbContext(options)
{
    public DbSet<TaskItem> TaskItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // seed a single task
        modelBuilder.Entity<TaskItem>().HasData(
            new 
            {
                Id = Guid.NewGuid(),
                Name = "Dummy 1",
                Description = "This is a dummy task",
                IsCompleted = false
            }
        );
    }
}