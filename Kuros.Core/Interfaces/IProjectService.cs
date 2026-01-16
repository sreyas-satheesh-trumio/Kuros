using Kuros.Core.DTOs.Projects;

namespace Kuros.Core.Interfaces;

public interface IProjectService
{
    Task<ProjectCreateResponseDto?> CreateAsync(ProjectCreateDto dto);
    Task<IEnumerable<ProjectResponseDto>> GetAllAsync(Guid userId);
    Task<ProjectResponseDto?> GetByIdAsync(Guid id);
    Task<ProjectResponseDto?> UpdateAsync(Guid id, ProjectUpdateDto dto);
    Task<ProjectDeleteResponseDto?> DeleteAsync(Guid id);
}
