namespace Kuros.Core.DTOs.Projects;

public class ProjectDeleteResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = string.Empty;
}
