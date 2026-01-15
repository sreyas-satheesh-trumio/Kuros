using Kuros.Core.DTOs.TaskItems;

namespace Kuros.Core.Interfaces;

public interface ITaskItemService
{
    Task<TaskItemResponseDto?> CreateAsync(TaskItemCreateDto dto);
    Task<IEnumerable<TaskItemResponseDto>> GetByProjectAsync(Guid projectId);
    Task<TaskItemResponseDto?> GetByIdAsync(Guid id);
    Task<TaskItemResponseDto?> UpdateAsync(Guid id, TaskItemUpdateDto dto);
    Task<TaskItemMoveResponseDto?> MoveAsync(Guid id, TaskItemMoveDto status);
    Task<TaskItemResponseDto?> DeleteAsync(Guid id);
}
