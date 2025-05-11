using TaskManager.Domain.DTOs;

namespace TaskManager.Domain.Interfaces.UseCase;
public interface ICreateTaskUseCase
{
    Task<TaskInfoDto> ExecuteAsync(TaskInfoDto taskInfoDto);
}
