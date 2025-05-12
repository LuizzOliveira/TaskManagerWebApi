using TaskManager.Domain.DTOs.Request;
using TaskManager.Domain.DTOs.Response;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Domain.Interfaces.UseCase;

namespace TaskManager.Application.UseCase;

    public class CreateTaskUseCase(IUnitOfWork unitOfWork) : ICreateTaskUseCase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ResponseTaskInfoDto> ExecuteAsync(RequestTaskInfoDto taskInfoDto)
    {
        var task = new TasksEntity();
        task.UpdateTasks(taskInfoDto.Description, taskInfoDto.Name);

        await _unitOfWork.Tasks.AddAsync(task);
        await _unitOfWork.SaveChangesAsync();

        return new ResponseTaskInfoDto(task.Id, task.Name!, task.Description!);
    }
}