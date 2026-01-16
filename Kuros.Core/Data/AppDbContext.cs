using Microsoft.EntityFrameworkCore;
using Kuros.Core.Entities;

namespace Kuros.Core.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Project> Projects => Set<Project>();
    public DbSet<TaskItem> TaskItems => Set<TaskItem>();
    public DbSet<ProjectPayments> ProjectPayments => Set<ProjectPayments>();
    public DbSet<UserSkills> UserSkills => Set<UserSkills>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Client> Clients => Set<Client>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
