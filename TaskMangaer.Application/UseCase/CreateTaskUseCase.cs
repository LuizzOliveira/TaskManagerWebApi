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
    public async Task<ResponseTaskInfoDto> ExecuteAsync(
        RequestTaskInfoDto taskInfoDto,
        CancellationToken ct
        )
    {
        var task = TasksEntity.Create(taskInfoDto.Name, taskInfoDto.Description);

        await repository.AddAsync(task, ct);

        await repository.SaveChangesAsync(ct);

        return new ResponseTaskInfoDto(task.Id, task.Name!, task.Description!);  
    }
}