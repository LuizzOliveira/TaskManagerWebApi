using Microsoft.AspNetCore.Mvc;
using TaskManager.Domain.DTOs.Request;
using TaskManager.Domain.DTOs.Response;
using TaskManager.Domain.Interfaces.UseCase;

namespace TaskManager.API.Endpoints;
public static class TaskEndpoints
{
    public static WebApplication MapTaskEndpoints(this WebApplication app)
    {
        var root = app.MapGroup("/task")
            .WithTags("Tasks")
            .WithDescription("Tasks Manager");

        root.MapGet("", async (
            IGetAllTasksUseCase useCase, 
            CancellationToken ct 
            ) =>
        {
            var tasks = await useCase.ExecuteAsync(ct);
            return Results.Ok(tasks);
        })
        .WithSummary("Get all tasks")
        .WithDescription("Retrieves a list of all registered tasks with their status.")
        .Produces<IEnumerable<TaskResponseDto>>(StatusCodes.Status200OK)
        .WithOpenApi();

        root.MapGet("{id}", async (
            [FromRoute] long id, 
            IGetTaskByIdUseCase useCase,
            CancellationToken ct
            ) =>
        {
            var result = await useCase.ExecuteAsync(id, ct);

            return result is null
                ? Results.NotFound()
                : Results.Ok(result);
        })
        .WithSummary("Busca tarefa por ID")
        .WithDescription("Retorna os detalhes de uma tarefa específica usando seu ID.")
        .Produces<TaskDetailsDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();


        root.MapPost("/create", async (
            [FromBody] RequestTaskInfoDto taskInfoDto,
            ICreateTaskUseCase useCase,
            CancellationToken ct
            ) =>
        {
            var createdTask = await useCase.ExecuteAsync(taskInfoDto, ct);
            return Results.Created($"/tasks/{createdTask.Id}", createdTask);
        })
        .WithSummary("Create a new task")
        .WithDescription("Creates a task with the provided name and description.")
        .Produces<TaskDetailsDto>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .WithOpenApi();

        root.MapPut("/update/{id}", async (
            [FromRoute] long id,
            [FromBody] RequestTaskInfoDto taskInfoDto,
            IUpdateTaskUseCase useCase,
            CancellationToken ct
            ) =>
        {
            var result = await useCase.ExecuteAsync(id, taskInfoDto, ct);

            return result ? Results.NoContent() : Results.NotFound();
        })
        .WithSummary("Update a task")
        .WithDescription("Updates an existing task by ID with the provided name and description.")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();

        root.MapPatch("/completed", async (
            [FromQuery] string name,
            ICompleteTaskUseCase useCase,
            CancellationToken ct
            ) =>
        {
            var result = await useCase.ExecuteAsync(name, ct);

            return result
                ? Results.Ok("Task completed")
                : Results.NotFound();
        })
        .WithSummary("Mark task as completed")
        .WithDescription("Marks the task as completed by searching with name.")
        .Produces<string>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();


        root.MapDelete("/delete", async (
            [FromQuery] long id,
            IDeleteTaskUseCase useCase,
            CancellationToken ct
            ) =>
        {
            var deleted = await useCase.ExecuteAsync(id, ct);
            return deleted ? Results.NoContent() : Results.NotFound();
        })
        .WithSummary("Delete task by ID")
        .WithDescription("Deletes a task by its unique identifier.")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();

        return app;
    }
}
