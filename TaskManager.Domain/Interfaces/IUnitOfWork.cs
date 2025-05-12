using TaskManager.Domain.Interfaces.Repository;

namespace TaskManager.Domain.Interfaces;
public interface IUnitOfWork
{
    ITaskRepository Tasks { get; }
    Task SaveChangesAsync();
}