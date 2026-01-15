using Microsoft.AspNetCore.Mvc;
using Kuros.Core.DTOs.Projects;
using Kuros.Core.Interfaces;

[ApiController]
[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _service;

    public ProjectsController(IProjectService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProjectCreateDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectResponseDto>> Get(Guid id)
    {
        ProjectResponseDto? res = await _service.GetByIdAsync(id);
        if (res == null) return NotFound();
        return Ok(res);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProjectResponseDto>> Update(Guid id, ProjectUpdateDto dto)
    {
        ProjectResponseDto? res = await _service.UpdateAsync(id, dto);
        if (res == null) return NotFound();
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ProjectDeleteResponseDto>> Delete(Guid id)
    {
        ProjectDeleteResponseDto? res = await _service.DeleteAsync(id);
        if (res == null) return NotFound();
        return Ok(res);
    }
}
