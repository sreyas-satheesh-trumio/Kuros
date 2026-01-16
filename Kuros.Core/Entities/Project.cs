namespace Kuros.Core.Entities;

public class Project
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int HourlyPayRate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public Guid? ClientId { get; set; }
    public Client? Client { get; set; }
    public ICollection<TaskItem> TaskItems { get; set; } = [];
}