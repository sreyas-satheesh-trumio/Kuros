public interface ITaskItemService
{
    Task<TaskItemResponseDto> CreateAsync(TaskItemCreateDto dto);
    Task<IEnumerable<TaskItemResponseDto>> GetByProjectAsync(Guid projectId);
    Task<TaskItemResponseDto?> GetByIdAsync(Guid id);
    Task UpdateAsync(Guid id, TaskItemUpdateDto dto);
    Task MoveAsync(Guid id, TaskItemMoveDto status);
    Task DeleteAsync(Guid id);
}
