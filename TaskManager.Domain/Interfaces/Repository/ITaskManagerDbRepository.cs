using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces.Repository;
public interface ITaskRepository
{
    Task AddAsync(TasksEntity task, CancellationToken ct);
    Task<TasksEntity?> GetByIdAsync(long id, CancellationToken ct);
    Task<TasksEntity?> GetByNameAsync(string name, CancellationToken ct);
    Task<IEnumerable<TasksEntity>> GetAllAsync(CancellationToken ct);
    Task SaveChangesAsync(CancellationToken ct);
    Task<TasksEntity?> GetByNamePartialAsync(string name, CancellationToken ct);
    Task UpdateAsync(TasksEntity task, CancellationToken ct);
    Task DeleteAsync(TasksEntity task, CancellationToken ct);
}
