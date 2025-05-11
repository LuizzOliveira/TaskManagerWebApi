using TaskManager.Domain.DTOs;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repository;
using TaskManager.Domain.Interfaces.UseCase;

namespace TaskManager.Application.UseCase;

public class CreateTaskUseCase(
    ITaskRepository repository
    ) : ICreateTaskUseCase
{
    private readonly ITaskRepository _repository = repository;

    public async Task<TaskInfoDto> ExecuteAsync(TaskInfoDto taskInfoDto)
    {
        var task = new TasksEntity();
        task.UpdateTasks(taskInfoDto.Description, taskInfoDto.Name);

        await _repository.AddAsync(task);
        await _repository.SaveChangesAsync();

        return new TaskInfoDto(task.Name!, task.Description!);
    }
}