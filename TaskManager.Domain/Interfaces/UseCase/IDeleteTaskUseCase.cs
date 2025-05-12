namespace TaskManager.Domain.Interfaces.UseCase;
public interface IDeleteTaskUseCase
{
    Task<bool> ExecuteAsync(string id);
}