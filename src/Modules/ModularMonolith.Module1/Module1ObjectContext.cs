using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ModularMonolith.Module1;

public class Module1ObjectContext : DbContext
{
    public Module1ObjectContext(DbContextOptions<Module1ObjectContext> options) : base(options) { }
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