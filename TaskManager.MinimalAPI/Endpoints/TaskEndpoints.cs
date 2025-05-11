using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.DTOs;
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

        root.MapGet("", async (TaskManagerDb db) =>
            await db.TasksEntity.OrderBy(x => x.Name).Select(x => x).ToListAsync());

        root.MapGet("{id}", async (string id, TaskManagerDb db) =>
            await db.TasksEntity.FindAsync(id) is TasksEntity task
            ? Results.Ok(task)
            : Results.NotFound());

        root.MapPost("/create", async (
                TaskInfoDto taskInfoDto,
                ICreateTaskUseCase useCase) =>
        {
            if (string.IsNullOrWhiteSpace(taskInfoDto.Name) || string.IsNullOrWhiteSpace(taskInfoDto.Description))
            {
                return Results.BadRequest("Name and Description are required.");
            }

            var createdTask = await useCase.ExecuteAsync(taskInfoDto);
            return Results.Created($"/task/{createdTask.Name}", createdTask);
        })
        .WithName("CreateTask")
        .WithSummary("Create a new task")
        .WithDescription("Creates a task with the provided name and description.")
        .Produces<TaskInfoDto>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .WithOpenApi();

        root.MapPut("/update/{id}", async (string id, TaskInfoDto taskInfoDto, TaskManagerDb db) =>
        {
            var task = await db.TasksEntity.FindAsync(id);

            if (task is null)
                return Results.NotFound();

            task.UpdateTasks(
                taskInfoDto.Name,
                taskInfoDto.Description);

            await db.SaveChangesAsync();

            return Results.NoContent();
        });

        root.MapPut("/completed/{name}", async (string name, TaskManagerDb db) =>
        {
            var task = await db.TasksEntity
                .FirstOrDefaultAsync(t => t.Name != null && t.Name.ToLower().Contains(name.ToLower()));

            if (task is null)
                return Results.NotFound();

            task.UpdateCompletedTasks();

            await db.SaveChangesAsync();

            return Results.NoContent();
        });

        root.MapDelete("/delete/{id}", async (string id, TaskManagerDb db) =>
        {
            var task = await db.TasksEntity.FindAsync(id);

            if (task is null)
                return Results.NotFound();

            db.TasksEntity.Remove(task);

            await db.SaveChangesAsync();

            return Results.NoContent();
        });

        return app;
    }
}
