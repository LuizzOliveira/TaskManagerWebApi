using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Data;

public class TaskManagerDb(DbContextOptions<TaskManagerDb> options) : DbContext(options)
{
    public DbSet<TasksEntity> TasksEntity { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TasksEntity>()
            .Property(t => t.Completed)
            .HasConversion<string>()
            .HasMaxLength(20);
    }
}