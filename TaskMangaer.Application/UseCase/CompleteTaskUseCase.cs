using TaskManager.Domain.Interfaces.Repository;
using TaskManager.Domain.Interfaces.UseCase;

namespace TaskManager.Application.UseCase;
public class CompleteTaskUseCase(
    ITaskRepository repository
    ) : ICompleteTaskUseCase
{
    public async Task<bool> ExecuteAsync(
        string name,
        CancellationToken ct
        )
    {
        if (string.IsNullOrWhiteSpace(name))
            return false;

        var task = await repository.GetByNamePartialAsync(name, ct);

        if (task is null)
            return false;

        task.UpdateCompletedTasks(true);

        await repository.UpdateAsync(task, ct);

        await repository.SaveChangesAsync(ct);

        return true;
    }
}
