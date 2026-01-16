namespace Kuros.Core.Entities;

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? MobileNumber { get; set; }
    public string? Location { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
    public int? HourlyPayRate { get; set; }
    public ICollection<UserSkills> Skills { get; set; } = new List<UserSkills>();
}