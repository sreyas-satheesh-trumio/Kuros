using System.ComponentModel.DataAnnotations;
using Kuros.Core.Enums;

namespace Kuros.Core.DTOs.TaskItems;

public class TaskItemMoveDto
{
    [Required(ErrorMessage = "Task Status is required.")]
    public TaskItemStatus Status { get; set; }
}
