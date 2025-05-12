namespace TaskManager.Domain.DTOs.Response;
public record TaskDetailsDto(
    string Id,
    string Name,
    string Description,
    string Completed,
    DateTime DateRegistration,
    DateTime? DateCompleted
);
