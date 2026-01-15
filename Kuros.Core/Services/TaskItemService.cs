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

    public async Task<TaskItemResponseDto?> CreateAsync(TaskItemCreateDto dto)
    {
        var project = await _db.Projects.FindAsync(dto.ProjectId);
        if (project == null) return null;

        var task = new TaskItem { 
            ProjectId = dto.ProjectId, 
            Name = dto.Title ?? "", 
            Description = dto.Description, 
            TaskItemStatus = dto.TaskItemStatus, 
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _db.TaskItems.Add(task);
        await _db.SaveChangesAsync();

        return new TaskItemResponseDto
        {
            Id = task.Id,
            ProjectId = task.ProjectId,
            Title = task.Name,
            Description = task.Description,
            TaskItemStatus = task.TaskItemStatus,
            CreatedAt = task.CreatedAt,
            UpdatedAt = task.UpdatedAt
        };
    }

    public async Task<IEnumerable<TaskItemResponseDto>> GetByProjectAsync(Guid projectId)
    {
        return _db.TaskItems
            .Where(t => t.ProjectId == projectId)
            .Select(t => new TaskItemResponseDto
            {
                Id = t.Id,
                ProjectId = t.ProjectId,
                Title = t.Name,
                Description = t.Description,
                TaskItemStatus = t.TaskItemStatus,
                CreatedAt = t.CreatedAt,
                UpdatedAt = t.UpdatedAt
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
            Description = task.Description,
            TaskItemStatus = task.TaskItemStatus,
            CreatedAt = task.CreatedAt,
            UpdatedAt = task.UpdatedAt
        };
    }

    public async Task<TaskItemResponseDto?> UpdateAsync(Guid id, TaskItemUpdateDto dto)
    {
        var task = await _db.TaskItems.FindAsync(id);
        if (task == null) return null;

        task.Name = string.IsNullOrEmpty(dto.Title) ? task.Name : dto.Title;
        task.Description = string.IsNullOrEmpty(dto.Description) ? task.Description : dto.Description;
        await _db.SaveChangesAsync();

        return new TaskItemResponseDto
        {
            Id = task.Id,
            ProjectId = task.ProjectId,
            Title = task.Name,
            Description = task.Description,
            TaskItemStatus = task.TaskItemStatus,
            CreatedAt = task.CreatedAt,
            UpdatedAt = task.UpdatedAt
        };
    }

    public async Task<TaskItemMoveResponseDto?> MoveAsync(Guid id, TaskItemMoveDto status)
    {
        var task = await _db.TaskItems.FindAsync(id);
        if (task == null) return null;

        task.TaskItemStatus = status.Status;
        await _db.SaveChangesAsync();

        return new TaskItemMoveResponseDto
        {
            TaskItemStatus = task.TaskItemStatus
        };
    }

    public async Task<TaskItemResponseDto?> DeleteAsync(Guid id)
    {
        var task = await _db.TaskItems.FindAsync(id);
        if (task == null) return null;
    
        _db.TaskItems.Remove(task);
        await _db.SaveChangesAsync();

        return new TaskItemResponseDto
        {
            Id = task.Id,
            ProjectId = task.Project?.Id ?? Guid.Empty,
            Title = task.Name,
            Description = task.Description,
            TaskItemStatus = task.TaskItemStatus,
            CreatedAt = task.CreatedAt,
            UpdatedAt = task.UpdatedAt
        };
    }
}
