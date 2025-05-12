using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.UseCase;
using TaskManager.Domain.Interfaces.UseCase;

namespace TaskManager.Application.Extensions.UseCase;
public static class ConfigureUseCaseExtensions
{
    public static IServiceCollection AddTaskUseCases(this IServiceCollection services)
    {
        services.AddTransient<ICreateTaskUseCase, CreateTaskUseCase>();
        services.AddTransient<IGetAllTasksUseCase, GetAllTasksUseCase>();
        services.AddTransient<IGetTaskByIdUseCase, GetTaskByIdUseCase>();
        services.AddTransient<IUpdateTaskUseCase, UpdateTaskUseCase>();
        services.AddTransient<IDeleteTaskUseCase, DeleteTaskUseCase>();
        services.AddTransient<ICompleteTaskUseCase, CompleteTaskUseCase>();

        return services;
    }
}