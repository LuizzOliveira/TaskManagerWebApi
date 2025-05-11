using TaskManager.API.Endpoints;

namespace TaskManager.API.Extensions;

public static class EndpointExtensions
{
    public static IEndpointRouteBuilder AddEndpoints(this WebApplication app)
           => app.MapTaskEndpoints();
}