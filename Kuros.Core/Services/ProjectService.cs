using Kuros.Core.Data;
using Kuros.Core.DTOs.Projects;
using Kuros.Core.Entities;
using Kuros.Core.Interfaces;

namespace Kuros.Core.Services;

public class ProjectService : IProjectService
{
    private readonly AppDbContext _db;

    public ProjectService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<ProjectResponseDto> CreateAsync(ProjectCreateDto dto)
    {
        var project = new Project
        {
            Name = dto.Name ?? "",
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        _db.Projects.Add(project);
        await _db.SaveChangesAsync();

        return new ProjectResponseDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            CreatedAt = project.CreatedAt,
            UpdatedAt = project.UpdatedAt
        };
    }

    public async Task<IEnumerable<ProjectResponseDto>> GetAllAsync()
    {
        return _db.Projects
            .Select(p => new ProjectResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            })
            .OrderByDescending(p => p.CreatedAt)
            .ToList();
    }

    public async Task<ProjectResponseDto?> GetByIdAsync(Guid id)
    {
        return _db.Projects
            .Where(p => p.Id == id)
            .Select(p => new ProjectResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            })
            .FirstOrDefault();
    }

    public async Task<ProjectResponseDto?> UpdateAsync(Guid id, ProjectUpdateDto dto)
    {
        var project = await _db.Projects.FindAsync(id);
        if (project == null) return null;

        project.Name = dto.Name ?? project.Name;
        project.Description = dto.Description ?? project.Description;
        project.UpdatedAt = DateTime.UtcNow;
        await _db.SaveChangesAsync();

        return new ProjectResponseDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            CreatedAt = project.CreatedAt,
            UpdatedAt = project.UpdatedAt
        };
    }

    public async Task<ProjectDeleteResponseDto?> DeleteAsync(Guid id)
    {
        var project = await _db.Projects.FindAsync(id);
        if (project == null) return null;

        _db.Projects.Remove(project);
        await _db.SaveChangesAsync();

        return new ProjectDeleteResponseDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description
        };
    }
}
