namespace TaskManager.Domain.DTOs.Response;
public record TaskDetailsDto(
    long Id,
    string Name,
    string Description,
    string Completed,
    DateTime DateRegistration,
    DateTime? DateCompleted
);
