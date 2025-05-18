using TaskManager.Domain.DTOs.Request;
using TaskManager.Domain.DTOs.Response;

namespace TaskManager.Domain.Interfaces.UseCase;
public interface ICreateTaskUseCase
{
    Task<ResponseTaskInfoDto> ExecuteAsync(RequestTaskInfoDto taskInfoDto, CancellationToken ct);
}
