using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.DTOs.Response;
using TaskManager.Domain.Interfaces.UseCase;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Application.UseCase;
public class GetTaskByIdUseCase(TaskManagerDb db) : IGetTaskByIdUseCase
{
    private readonly TaskManagerDb _db = db;

    public async Task<TaskDetailsDto?> ExecuteAsync(long id)
    {
        var task = await _db.TasksEntity
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (task is null) return null;

        return new TaskDetailsDto(
            task.Id,
            task.Name ?? string.Empty,
            task.Description ?? string.Empty,
            task.Completed.ToString(),
            task.DateRegistration,
            task.DateCompleted
        );
    }
}
