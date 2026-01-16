namespace Kuros.Core.Entities;

public class UserSkills
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string SkillName { get; set; } = string.Empty;
    public SkillProficiency ProficiencyLevel { get; set; }
    public User? User { get; set; }
}