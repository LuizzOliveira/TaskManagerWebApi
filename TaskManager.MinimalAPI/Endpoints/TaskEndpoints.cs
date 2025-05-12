using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.DTOs.Request;
using TaskManager.Domain.DTOs.Response;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.UseCase;
using TaskManager.Infrastructure.Data;

namespace TaskManager.API.Endpoints;
public static class TaskEndpoints
{
    public static WebApplication MapTaskEndpoints(this WebApplication app)
    {
        var root = app.MapGroup("/task")
            .WithTags("Tasks")
            .WithDescription("Tasks Manager");

        root.MapGet("", async (IGetAllTasksUseCase useCase) =>
        {
            var tasks = await useCase.ExecuteAsync();
            return Results.Ok(tasks);
        })
        .WithName("GetAllTasks")
        .WithSummary("Get all tasks")
        .WithDescription("Retrieves a list of all registered tasks with their status.")
        .Produces<List<TaskResponseDto>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status500InternalServerError)
        .WithOpenApi();

        root.MapGet("{id}", async (
            string id, IGetTaskByIdUseCase useCase
            ) =>
        {
            var result = await useCase.ExecuteAsync(id);

            return result is null
                ? Results.NotFound()
                : Results.Ok(result);
        })
        .WithName("GetTaskById")
        .WithSummary("Busca tarefa por ID")
        .WithDescription("Retorna os detalhes de uma tarefa específica usando seu ID.")
        .Produces<TaskDetailsDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();


        root.MapPost("/create", async (
            RequestTaskInfoDto taskInfoDto,
            ICreateTaskUseCase useCase
            ) =>
        {
            var createdTask = await useCase.ExecuteAsync(taskInfoDto);
            return Results.Created($"/tasks/{createdTask.Id}", createdTask);
        })

        .WithName("CreateTask")
        .WithSummary("Create a new task")
        .WithDescription("Creates a task with the provided name and description.")
        .Produces<TaskDetailsDto>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .WithOpenApi();

        root.MapPut("/update/{id}", async (
            string id,
            RequestTaskInfoDto taskInfoDto,
            IUpdateTaskUseCase useCase
            ) =>
        {
            var result = await useCase.ExecuteAsync(id, taskInfoDto);

            return result ? Results.NoContent() : Results.NotFound();
        })
        .WithName("UpdateTask")
        .WithSummary("Update a task")
        .WithDescription("Updates an existing task by ID with the provided name and description.")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();

        root.MapPut("/completed/{name}", async (
            string name,
            ICompleteTaskUseCase useCase
            ) =>
        {
            var result = await useCase.ExecuteAsync(name);

            return result ? Results.NoContent() : Results.NotFound();
        })
        .WithName("CompleteTask")
        .WithSummary("Mark task as completed")
        .WithDescription("Marks the task as completed by searching with name.")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();

        root.MapDelete("/delete/{id}", async (
            string id,
            IDeleteTaskUseCase useCase) =>
        {
            var deleted = await useCase.ExecuteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        })
        .WithName("DeleteTask")
        .WithSummary("Delete task by ID")
        .WithDescription("Deletes a task by its unique identifier.")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .WithOpenApi();

        return app;
    }
}
