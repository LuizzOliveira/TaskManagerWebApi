using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enum;

namespace TaskManager.Infrastructure.Data;

public class TaskManagerDb(IConfiguration configuration, DbContextOptions<TaskManagerDb> options)
    : DbContext(options)
{
    private readonly IConfiguration _configuration = configuration;
    public DbSet<TasksEntity> TasksEntity { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var typeDatabase = _configuration["TypeDatabase"];

        if (string.IsNullOrEmpty(typeDatabase))
        {
            throw new InvalidOperationException("Database type is not specified in the connection string.");
        }

        var connectionString = _configuration.GetConnectionString(typeDatabase);
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TasksEntity>()
            .Property(t => t.Completed)
            .HasConversion<string>()
            .HasMaxLength(20);
    }
}