using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.Domain.Enum;

namespace TaskManager.Domain.Entities;

public class TasksEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; private set; }
    public string? Name { get; private set; }
    public string? Description { get; private set; }

    [Column(TypeName = "varchar(20)")]
    public ETaskStatus Completed { get; private set; }
    public DateTime DateRegistration { get; private set; }
    public DateTime? DateCompleted { get; private set; }
    protected TasksEntity() { }

    [NotMapped]
    public string CompletedName => Completed.ToString();

    public TasksEntity(string? name, string? description, DateTime dateRegistration)
    {
        Name = name;
        Description = description;
        DateRegistration = dateRegistration;
        Completed = ETaskStatus.Incomplete;
    }

    public void UpdateTasks(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void UpdateCompletedTasks(bool? completed)
    {
        if (!completed.HasValue) return;

        Completed = completed.Value ? ETaskStatus.Complete : ETaskStatus.Incomplete;
        DateCompleted = completed.Value ? DateTime.Now : null;
    }

    public static TasksEntity Create(string name, string? description)
    {
        return new TasksEntity(name, description, DateTime.UtcNow);
    }
}
