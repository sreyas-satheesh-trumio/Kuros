using System.ComponentModel.DataAnnotations;
using Kuros.Core.Enums;

namespace Kuros.Core.DTOs.TaskItems;

public class TaskItemCreateDto
{
    [Required(ErrorMessage = "{0} is required.")]
    public Guid ProjectId { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [MinLength(3, ErrorMessage = "{0} must be at least 3 characters long.")]
    [MaxLength(100, ErrorMessage = "{0} cannot exceed 100 characters.")]
    public string? Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public TaskItemStatus TaskItemStatus { get; set; } = TaskItemStatus.BackLog;
}
