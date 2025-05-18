namespace TaskManager.Domain.Interfaces.UseCase;
public interface IDeleteTaskUseCase
{
    Task<bool> ExecuteAsync(long id, CancellationToken ct);
}