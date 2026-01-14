using Kuros.Core.Enums;

namespace Kuros.Core.Entities;

public class TaskItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public TaskItemStatus TaskItemStatus { get; set; } = TaskItemStatus.BackLog;

    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }
}