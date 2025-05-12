namespace TaskManager.Domain.DTOs.Response;

public record TaskResponseDto(
    long Id,
    string? Name,
    string? Description,
    string Completed,
    DateTime DateRegistration,
    DateTime? DateCompleted
);
