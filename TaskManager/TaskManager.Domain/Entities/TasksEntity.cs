namespace TaskManager.Domain.Entities;

public class TasksEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool Completed { get; set; } = false;
    public DateTime DateRegistration { get; private set; } = DateTime.Now;
    public DateTime? DateCompleted { get; private set; } = null;

    public void UpdateTasks(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void UpdateCompletedTasks(bool? completed = true)
    {
        if (completed.HasValue)
            Completed = completed.Value;
            DateCompleted = DateTime.Now;
    }

}
