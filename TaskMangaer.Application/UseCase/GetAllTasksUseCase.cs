using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.DTOs.Response;
using TaskManager.Domain.Interfaces.UseCase;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Application.UseCase;
public class GetAllTasksUseCase(TaskManagerDb db) : IGetAllTasksUseCase
{
    private readonly TaskManagerDb _db = db;

    public async Task<IEnumerable<TaskResponseDto>> ExecuteAsync()
    {
        return await _db.TasksEntity
            .OrderBy(t => t.Name)
            .Select(t => new TaskResponseDto(
                t.Id,
                t.Name,
                t.Description,
                t.Completed.ToString(),
                t.DateRegistration,
                t.DateCompleted
            ))
            .ToListAsync();
    }
}
