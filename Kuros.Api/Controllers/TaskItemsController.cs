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
    public async Task<ActionResult<TaskItemResponseDto>> Create(TaskItemCreateDto dto)
    {
        var res = await _service.CreateAsync(dto);
        if (res == null) return NotFound();
        return Ok(res);
    }

    [HttpGet("project/{projectId}")]
    public async Task<ActionResult<IEnumerable<TaskItemResponseDto>>> GetByProject(Guid projectId)
    {
        var res = await _service.GetByProjectAsync(projectId);
        if (res == null) return NotFound();
        return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItemResponseDto>> GetById(Guid id)
    {
        var res = await _service.GetByIdAsync(id);
        if (res == null) return NotFound();
        return Ok(res);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TaskItemResponseDto>> Update(Guid id, TaskItemUpdateDto dto)
    {
        var res = await _service.UpdateAsync(id, dto);
        if (res == null) return NotFound();
        return Ok(res);
    }

    [HttpPut("{id}/move")]
    public async Task<ActionResult<TaskItemMoveResponseDto>> Move(Guid id, TaskItemMoveDto dto)
    {
        var res = await _service.MoveAsync(id, dto);
        if (res == null) return NotFound();
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<TaskItemResponseDto>> Delete(Guid id)
    {
        var res = await _service.DeleteAsync(id);
        if (res == null) return NotFound();
        return Ok(res);
    }
}
