using TaskManager.Domain.Interfaces.Repository;
using TaskManager.Domain.Interfaces.UseCase;

namespace TaskManager.Application.UseCase;
public class DeleteTaskUseCase(
    ITaskRepository repository
    ) : IDeleteTaskUseCase
{
    public async Task<bool> ExecuteAsync(
        long id, 
        CancellationToken ct
        )
    {
        var task = await repository.GetByIdAsync(id, ct);
        if (task is null)
            return false;

        await repository.DeleteAsync(task, ct);

        await repository.SaveChangesAsync(ct);

        return true;
    }
}