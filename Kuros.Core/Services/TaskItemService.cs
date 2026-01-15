using Kuros.Core.Data;
using Kuros.Core.DTOs.TaskItems;
using Kuros.Core.Entities;
using Kuros.Core.Enums;
using Kuros.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kuros.Core.Services;

public class TaskItemService : ITaskItemService
{
    private readonly AppDbContext _db;

    public TaskItemService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<TaskItemResponseDto> CreateAsync(TaskItemCreateDto dto)
    {
        var task = new TaskItem { Id = dto.ProjectId, Name = dto.Title };
        _db.TaskItems.Add(task);
        await _db.SaveChangesAsync();

        return new TaskItemResponseDto
        {
            Id = task.Id,
            ProjectId = task.ProjectId,
            Title = task.Name,
            TaskItemStatus = task.TaskItemStatus
        };
    }

    public async Task<IEnumerable<TaskItemResponseDto>> GetByProjectAsync(Guid projectId)
    {
        return _db.TaskItems
            .Where(t => t.Id == projectId)
            .Select(t => new TaskItemResponseDto
            {
                Id = t.Id,
                ProjectId = t.ProjectId,
                Title = t.Name,
                TaskItemStatus = t.TaskItemStatus
            })
            .ToList();
    }

    public async Task<TaskItemResponseDto?> GetByIdAsync(Guid id)
    {
        var task = await _db.TaskItems
            .Include(t => t.Project)
            .FirstOrDefaultAsync(t => t.Id == id);

        return task == null ? null : new TaskItemResponseDto
        {
            Id = task.Id,
            ProjectId = task.Project?.Id ?? Guid.Empty,
            Title = task.Name,
            TaskItemStatus = task.TaskItemStatus
        };
    }

    public async Task UpdateAsync(Guid id, TaskItemUpdateDto dto)
    {
        var task = await _db.TaskItems.FindAsync(id);
        if (task == null) throw new KeyNotFoundException();

        task.Name = dto.Title;
        await _db.SaveChangesAsync();
    }

    public async Task MoveAsync(Guid id, TaskItemMoveDto status)
    {
        var task = await _db.TaskItems.FindAsync(id);
        if (task == null) throw new KeyNotFoundException();

        task.TaskItemStatus = status.Status;
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var task = await _db.TaskItems.FindAsync(id);
        if (task == null) return;

        _db.TaskItems.Remove(task);
        await _db.SaveChangesAsync();
    }
}
