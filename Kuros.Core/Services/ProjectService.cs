using Kuros.Core.Data;
using Kuros.Core.DTOs.Projects;
using Kuros.Core.Entities;
using Kuros.Core.Interfaces;
using Microsoft.Data.SqlClient;

namespace Kuros.Core.Services;

public class ProjectService : IProjectService
{
    private readonly AppDbContext _db;

    public ProjectService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<ProjectCreateResponseDto?> CreateAsync(ProjectCreateDto dto)
    {
        var userDetails = await _db.Users.FindAsync(AuthService.CurrentUserId);

        if (userDetails == null) return null;

        var project = new Project
        {
            Name = dto.Name ?? "",
            Description = dto.Description,
            HourlyPayRate = dto.HourlyPayRate ?? userDetails?.HourlyPayRate ?? 0,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            UserId = userDetails?.Id ?? Guid.Empty,
            ClientId = dto.ClientId
        };
        _db.Projects.Add(project);
        await _db.SaveChangesAsync();

        string clientName = "";
        if (dto.ClientId.HasValue)
        {
            var client = await _db.Clients.FindAsync(dto.ClientId);
            clientName = client?.Name ?? "";
        }

        return new ProjectCreateResponseDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            CreatedAt = project.CreatedAt,
            UpdatedAt = project.UpdatedAt,
            HourlyPayRate = project.HourlyPayRate,
            ClientName = clientName,
        };
    }

    public async Task<IEnumerable<ProjectResponseDto>> GetAllAsync(Guid userId)
    {
        var allProjects = _db.Projects
            .Where(p => p.UserId == userId)
            .OrderByDescending(p => p.CreatedAt)
            .Select(p => new ProjectResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            })
            .ToList();

        return allProjects;
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
