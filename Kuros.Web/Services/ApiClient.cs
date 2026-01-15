using System.Net.Http.Json;
using Kuros.Core.DTOs.Projects;
using Kuros.Core.DTOs.TaskItems;

namespace Kuros.Web.Services;

public class ApiClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "http://localhost:5076/";

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(BaseUrl);
    }

    // Projects endpoints
    public async Task<List<ProjectResponseDto>?> GetProjectsAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<ProjectResponseDto>>("/api/projects");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching projects: {ex.Message}");
            return null;
        }
    }

    public async Task<ProjectResponseDto?> GetProjectAsync(Guid id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<ProjectResponseDto>($"/api/projects/{id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching project: {ex.Message}");
            return null;
        }
    }

    public async Task<ProjectResponseDto?> CreateProjectAsync(ProjectCreateDto dto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/api/projects", dto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ProjectResponseDto>();
            }
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating project: {ex.Message}");
            return null;
        }
    }

    public async Task<ProjectResponseDto?> UpdateProjectAsync(Guid id, ProjectUpdateDto dto)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/projects/{id}", dto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ProjectResponseDto>();
            }
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating project: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> DeleteProjectAsync(Guid id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"/api/projects/{id}");
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting project: {ex.Message}");
            return false;
        }
    }

    // Tasks endpoints
    public async Task<List<TaskItemResponseDto>?> GetTasksByProjectAsync(Guid projectId)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<TaskItemResponseDto>>($"/api/tasks/project/{projectId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching tasks: {ex.Message}");
            return null;
        }
    }

    public async Task<TaskItemResponseDto?> CreateTaskAsync(TaskItemCreateDto dto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/api/tasks", dto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TaskItemResponseDto>();
            }
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating task: {ex.Message}");
            return null;
        }
    }

    public async Task<TaskItemResponseDto?> UpdateTaskAsync(Guid id, TaskItemUpdateDto dto)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/tasks/{id}", dto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TaskItemResponseDto>();
            }
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating task: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> DeleteTaskAsync(Guid id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"/api/tasks/{id}");
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting task: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> MoveTaskAsync(Guid id, TaskItemMoveDto dto)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/tasks/{id}/move", dto);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error moving task: {ex.Message}");
            return false;
        }
    }
}
