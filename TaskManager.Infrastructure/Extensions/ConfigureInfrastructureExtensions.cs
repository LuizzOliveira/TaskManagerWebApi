using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Domain.Interfaces.Repository;
using TaskManager.Infrastructure.Repository;

namespace TaskManager.Infrastructure.Extensions;
public static class ConfigureInfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITaskRepository, TaskRepository>();

        return services;
    }
}