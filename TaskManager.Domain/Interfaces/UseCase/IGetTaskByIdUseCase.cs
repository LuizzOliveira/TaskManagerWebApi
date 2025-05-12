using TaskManager.Domain.DTOs.Response;

namespace TaskManager.Domain.Interfaces.UseCase;
public interface IGetTaskByIdUseCase
{
    Task<TaskDetailsDto?> ExecuteAsync(string id);
}

