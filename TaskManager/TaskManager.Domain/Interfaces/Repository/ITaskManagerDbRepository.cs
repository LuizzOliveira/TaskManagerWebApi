using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces.Repository;
public interface ITaskRepository
{
    Task AddAsync(TasksEntity task);
    Task<TasksEntity?> GetByIdAsync(Guid id);
    Task<TasksEntity?> GetByNameAsync(string name);
    Task<IEnumerable<TasksEntity>> GetAllAsync();
    Task SaveChangesAsync();
}
