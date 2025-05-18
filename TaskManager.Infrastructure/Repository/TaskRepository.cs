using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repository;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repository;
public class TaskRepository(TaskManagerDb context) : ITaskRepository
{
    private readonly TaskManagerDb _context = context;

    public async Task AddAsync(TasksEntity task, CancellationToken ct)
    {
        await _context.TasksEntity.AddAsync(task, ct);
    }

    public async Task<TasksEntity?> GetByIdAsync(long id, CancellationToken ct)
    {
        return await _context.TasksEntity
            .FirstOrDefaultAsync(t => t.Id == id, ct);
    }

    public async Task<TasksEntity?> GetByNameAsync(string name, CancellationToken ct)
    {
        return await _context.TasksEntity.FirstOrDefaultAsync(t => t.Name == name, ct);
    }

    public async Task<IEnumerable<TasksEntity>> GetAllAsync(CancellationToken ct)
    {
        return await _context.TasksEntity.ToListAsync(ct);
    }

    public async Task SaveChangesAsync(CancellationToken ct)
    {
        await _context.SaveChangesAsync(ct);
    }

    public async Task<TasksEntity?> GetByNamePartialAsync(string name, CancellationToken ct)
    {
        return await _context.TasksEntity
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Name != null && t.Name.ToLower().Contains(name.ToLower()), ct);
    }

    public Task UpdateAsync(TasksEntity task, CancellationToken ct)
    {
        _context.TasksEntity.Update(task);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(TasksEntity task, CancellationToken ct)
    {
        _context.TasksEntity.Remove(task);
        return Task.CompletedTask; 
    }
}