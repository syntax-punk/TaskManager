using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManager.Entities;
using TaskManager.Models;

namespace TaskManager.Data;

public class TaskContext(DbContextOptions<TaskContext> options) : IdentityDbContext<User>(options)
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

        modelBuilder.Entity<User>()
            .HasData(
                new User()
                {
                    UserName = "bob@test.com",
                    Email = "bob@test.com",
                    PasswordHash = "",
                    EmailConfirmed = true
                }
            );
        
        modelBuilder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole
                {

                    Id = "1e266c6c-627b-4862-8465-8b1484457301",
                    Name = "Member",
                    NormalizedName = "MEMBER"
                },
                new IdentityRole
                {
                    Id = "9ecae3da-a04c-455a-819a-3af0fa92e844",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );
    }
}