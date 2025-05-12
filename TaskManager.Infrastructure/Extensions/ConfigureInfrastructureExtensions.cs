using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Domain.Interfaces;
using TaskManager.Domain.Interfaces.Repository;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.Repository;

namespace TaskManager.Infrastructure.Extensions;
public static class ConfigureInfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TaskManagerDb>(options =>
        {
            var typeDatabase = configuration["TypeDatabase"];

            if (string.IsNullOrEmpty(typeDatabase))
            {
                throw new ArgumentNullException(nameof(typeDatabase), "TypeDatabase is not configured.");
            }

            var connectionString = configuration.GetConnectionString(typeDatabase);
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });


        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}