using TaskManager.Domain.DTOs.Response;
using TaskManager.Domain.Interfaces.Repository;
using TaskManager.Domain.Interfaces.UseCase;

namespace TaskManager.Application.UseCase;
public class GetTaskByIdUseCase(
    ITaskRepository repository
    ) : IGetTaskByIdUseCase
{
    public async Task<TaskDetailsDto?> ExecuteAsync(
        long id,
        CancellationToken ct
        )
    {
        var task = await repository.GetByIdAsync(id, ct);

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
