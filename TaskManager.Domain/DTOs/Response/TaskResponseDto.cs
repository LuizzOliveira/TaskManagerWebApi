namespace TaskManager.Domain.DTOs.Response;

public record TaskResponseDto(
    string Id,
    string? Name,
    string? Description,
    string Completed,
    DateTime DateRegistration,
    DateTime? DateCompleted
);
