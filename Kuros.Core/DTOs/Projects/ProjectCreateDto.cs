using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class ProjectCreateDto
{
    [Required(ErrorMessage = "{0} is required.")]
    [MinLength(3, ErrorMessage = "{0} must be at least 3 characters long.")]
    [MaxLength(100, ErrorMessage = "{0} cannot exceed 100 characters.")]
    public string? Name { get; set; }
    public string Description { get; set; } = string.Empty;
}
