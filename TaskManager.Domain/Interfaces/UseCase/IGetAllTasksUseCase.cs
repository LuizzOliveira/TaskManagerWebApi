using TaskManager.Domain.DTOs.Response;

namespace TaskManager.Domain.Interfaces.UseCase;

public interface IGetAllTasksUseCase
{
    Task<IEnumerable<TaskResponseDto>> ExecuteAsync(CancellationToken ct);
}

