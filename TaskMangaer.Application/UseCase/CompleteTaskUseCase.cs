using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Interfaces.UseCase;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Application.UseCase;
public class CompleteTaskUseCase(TaskManagerDb context) : ICompleteTaskUseCase
{
    private readonly TaskManagerDb _context = context;

    public async Task<bool> ExecuteAsync(string name)
    {
        var task = await _context.TasksEntity
            .FirstOrDefaultAsync(t => t.Name != null && t.Name.ToLower()
            .Contains(name
                .ToLower()));

        if (task is null) return false;

        task.UpdateCompletedTasks(true);
        await _context.SaveChangesAsync();

        return true;
    }
}
