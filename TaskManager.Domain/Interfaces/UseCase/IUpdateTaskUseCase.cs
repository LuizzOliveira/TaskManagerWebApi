using TaskManager.Domain.DTOs.Request;

namespace TaskManager.Domain.Interfaces.UseCase;
public interface IUpdateTaskUseCase
{
    Task<bool> ExecuteAsync(string id, RequestTaskInfoDto dto);
}