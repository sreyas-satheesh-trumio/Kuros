public class TaskItemCreateDto
{
    public Guid ProjectId { get; set; }
    public string Title { get; set; } = default!;
}
