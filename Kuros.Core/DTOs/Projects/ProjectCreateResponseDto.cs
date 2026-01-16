namespace Kuros.Core.DTOs.Projects;

public class ProjectCreateResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int HourlyPayRate { get; set; }
    public string? ClientName { get; set; }
}
