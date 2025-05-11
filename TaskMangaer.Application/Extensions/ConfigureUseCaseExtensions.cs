using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Extensions.UseCase;

namespace TaskManager.Application.Extensions;
public static class ConfigureUseCaseExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
        => services
            .AddTaskUseCases();
}
