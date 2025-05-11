using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.Domain.Enum;

namespace TaskManager.Domain.Entities;
public class TasksEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string? Name { get; set; }

    public string? Description { get; set; }

    [Column(TypeName = "varchar(20)")]
    public ETaskStatus Completed { get; private set; } = ETaskStatus.Incomplete;

    public DateTime DateRegistration { get; private set; } = DateTime.Now;

    public DateTime? DateCompleted { get; private set; }

    public void UpdateTasks(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void UpdateCompletedTasks(bool? completed = true)
    {
        if (!completed.HasValue) return;

        Completed = completed.Value ? ETaskStatus.Complete : ETaskStatus.Incomplete;
        DateCompleted = completed.Value ? DateTime.Now : null;
    }
}
