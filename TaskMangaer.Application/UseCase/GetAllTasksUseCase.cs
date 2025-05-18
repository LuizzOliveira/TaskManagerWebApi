using TaskManager.Domain.DTOs.Response;
using TaskManager.Domain.Interfaces.Repository;
using TaskManager.Domain.Interfaces.UseCase;

namespace TaskManager.Application.UseCase;
public class GetAllTasksUseCase(
    ITaskRepository repository
    ) : IGetAllTasksUseCase
{
    public async Task<IEnumerable<TaskResponseDto>> ExecuteAsync(
        CancellationToken ct
        )
    {
        var tasks = await repository.GetAllAsync(ct);

        if (tasks is null || !tasks.Any())
            return [];

        return tasks.Select(t => new TaskResponseDto(
            t.Id,
            t.Name,
            t.Description,
            t.Completed.ToString(),
            t.DateRegistration,
            t.DateCompleted
        ));
    }
}