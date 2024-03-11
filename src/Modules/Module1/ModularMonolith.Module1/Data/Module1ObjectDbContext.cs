using System.Reflection;

using Microsoft.EntityFrameworkCore;

namespace ModularMonolith.Module1.Data;

public class Module1ObjectDbContext : DbContext
{
    public Module1ObjectDbContext(DbContextOptions<Module1ObjectDbContext> options) : base(options) { }
    internal DbSet<Module1Object> Module1Objects { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Module1Objects");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HavePrecision(18, 6);
    }
}