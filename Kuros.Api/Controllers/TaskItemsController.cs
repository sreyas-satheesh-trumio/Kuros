using Microsoft.AspNetCore.Mvc;
using Kuros.Core.DTOs.TaskItems;
using Kuros.Core.Interfaces;

[ApiController]
[Route("api/tasks")]
public class TaskItemsController : ControllerBase
{
    private readonly ITaskItemService _service;

    public TaskItemsController(ITaskItemService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskItemCreateDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpGet("project/{projectId}")]
    public async Task<IActionResult> GetByProject(Guid projectId)
        => Ok(await _service.GetByProjectAsync(projectId));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, TaskItemUpdateDto dto)
    {
        await _service.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpPut("{id}/move")]
    public async Task<IActionResult> Move(Guid id, TaskItemMoveDto dto)
    {
        await _service.MoveAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
