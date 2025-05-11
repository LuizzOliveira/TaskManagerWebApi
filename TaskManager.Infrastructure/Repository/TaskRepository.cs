using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repository;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repository;
public class TaskRepository(TaskManagerDb context) : ITaskRepository
{
    private readonly TaskManagerDb _context = context;

    public async Task AddAsync(TasksEntity task)
    {
        await _context.TasksEntity.AddAsync(task);
    }

    public async Task<TasksEntity?> GetByIdAsync(Guid id)
    {
        return await _context.TasksEntity.FindAsync(id);
    }

    public async Task<TasksEntity?> GetByNameAsync(string name)
    {
        return await _context.TasksEntity.FirstOrDefaultAsync(t => t.Name == name);
    }

    public async Task<IEnumerable<TasksEntity>> GetAllAsync()
    {
        return await _context.TasksEntity.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
