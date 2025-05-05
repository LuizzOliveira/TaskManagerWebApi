using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Data;

public class TaskManagerDb(DbContextOptions<TaskManagerDb> options)
    : DbContext(options)
{
    public DbSet<TasksEntity> TasksEntity { get; set; }
}

//depois que migrar para TaskManagerDbContext dar comando (dotnet remove package Microsoft.EntityFrameworkCore.InMemory)