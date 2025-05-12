using TaskManager.Domain.DTOs.Request;
using TaskManager.Domain.DTOs.Response;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repository;
using TaskManager.Domain.Interfaces.UseCase;

namespace TaskManager.Application.UseCase;

public class CreateTaskUseCase(
    ITaskRepository repository
    ) : ICreateTaskUseCase
{
    private readonly ITaskRepository _repository = repository;

    public async Task<ResponseTaskInfoDto> ExecuteAsync(RequestTaskInfoDto taskInfoDto)
    {
        var task = new TasksEntity(taskInfoDto.Name, taskInfoDto.Description, DateTime.UtcNow);

        await _repository.AddAsync(task);
        await _repository.SaveChangesAsync();

        return new ResponseTaskInfoDto(task.Id, task.Name!, task.Description!);  
    }
}