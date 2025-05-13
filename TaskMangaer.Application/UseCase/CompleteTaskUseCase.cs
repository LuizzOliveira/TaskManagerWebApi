using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Interfaces.UseCase;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Application.UseCase;
public class CompleteTaskUseCase(TaskManagerDb context) : ICompleteTaskUseCase
{
    private readonly TaskManagerDb _context = context;

    public async Task<bool> ExecuteAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return false;

        var nameToSearch = name.ToLower();

        var task = await _context.TasksEntity
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Name != null && t.Name.ToLower().Contains(nameToSearch));

        if (task is null)
            return false;

        task.UpdateCompletedTasks(true);

        _context.TasksEntity.Update(task);
        await _context.SaveChangesAsync();

        return true;
    }
}
