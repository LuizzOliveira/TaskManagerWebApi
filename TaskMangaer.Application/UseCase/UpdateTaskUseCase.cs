using TaskManager.Domain.DTOs.Request;
using TaskManager.Domain.Interfaces.Repository;
using TaskManager.Domain.Interfaces.UseCase;

namespace TaskManager.Application.UseCase;
public class UpdateTaskUseCase(
    ITaskRepository repository
    ) : IUpdateTaskUseCase
{
    public async Task<bool> ExecuteAsync(
        long id, 
        RequestTaskInfoDto dto, 
        CancellationToken ct
        )
    {
        var task = await repository.GetByIdAsync(id, ct);
        if (task is null) return false;

        task.UpdateTasks(dto.Name, dto.Description);

        await repository.UpdateAsync(task, ct);

        await repository.SaveChangesAsync(ct);

        return true;
    }
}