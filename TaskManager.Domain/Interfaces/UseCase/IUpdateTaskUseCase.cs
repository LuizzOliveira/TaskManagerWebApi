using TaskManager.Domain.DTOs;

namespace TaskManager.Domain.Interfaces.UseCase;
public interface IUpdateTaskUseCase
{
    Task<bool> ExecuteAsync(string id, TaskInfoDto dto);
}