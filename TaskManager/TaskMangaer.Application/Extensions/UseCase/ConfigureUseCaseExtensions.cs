using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.UseCase;
using TaskManager.Domain.Interfaces.UseCase;

namespace TaskManager.Application.Extensions.UseCase;
public static class ConfigureUseCaseExtensions
{
    public static IServiceCollection AddTaskUseCases(this IServiceCollection services)
    {
        services.AddTransient<ICreateTaskUseCase, CreateTaskUseCase>();

        return services;
    }
}