namespace Kuros.Core.Entities;

public class ProjectPayments
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public Project? Project { get; set; }
}