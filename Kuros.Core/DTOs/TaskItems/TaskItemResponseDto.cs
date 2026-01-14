using Kuros.Core.Enums;

public class TaskItemResponseDto
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public string Title { get; set; } = default!;
    public TaskItemStatus TaskItemStatus { get; set; }
}
