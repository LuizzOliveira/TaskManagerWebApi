using TaskManager.Domain.Interfaces;
using TaskManager.Domain.Interfaces.Repository;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repository;

public class UnitOfWork(TaskManagerDb context) : IUnitOfWork
{
    private readonly TaskManagerDb _context = context;

    public ITaskRepository Tasks => new TaskRepository(_context);

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
