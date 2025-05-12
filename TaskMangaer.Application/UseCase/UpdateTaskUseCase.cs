using TaskManager.Domain.DTOs.Request;
using TaskManager.Domain.DTOs.Response;
using TaskManager.Domain.Interfaces.UseCase;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Application.UseCase;
public class UpdateTaskUseCase(TaskManagerDb context) : IUpdateTaskUseCase
{
    private readonly TaskManagerDb _context = context;

    public async Task<bool> ExecuteAsync(string id, RequestTaskInfoDto dto)
    {
        var task = await _context.TasksEntity.FindAsync(id);
        if (task is null) return false;

        task.UpdateTasks(dto.Name, dto.Description);
        await _context.SaveChangesAsync();
        return true;
    }
}
