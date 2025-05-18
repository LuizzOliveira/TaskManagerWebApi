namespace TaskManager.Domain.Interfaces.UseCase;
public interface ICompleteTaskUseCase
{
    Task<bool> ExecuteAsync(string name, CancellationToken ct);
}