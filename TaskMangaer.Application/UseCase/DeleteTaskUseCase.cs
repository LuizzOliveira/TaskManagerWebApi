using TaskManager.Domain.Interfaces.UseCase;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Application.UseCase;
public class DeleteTaskUseCase(TaskManagerDb context) : IDeleteTaskUseCase
{
    private readonly TaskManagerDb _context = context;

    public async Task<bool> ExecuteAsync(string id)
    {
        var task = await _context.TasksEntity.FindAsync(id);
        if (task is null)
            return false;

        _context.TasksEntity.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }
}