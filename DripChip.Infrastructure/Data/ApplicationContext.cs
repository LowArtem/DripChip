using System.Reflection;
using DripChip.Core.Entities;
using DripChip.Core.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DripChip.Infrastructure.Data;

public class ApplicationContext : DbContext
{
    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<AnimalLocationPoint> LocationPoints { get; set; } = null!;
    public virtual DbSet<AnimalType> AnimalTypes { get; set; } = null!;
    public virtual DbSet<VisitedLocation> VisitedLocations { get; set; } = null!;
    public virtual DbSet<Animal> Animals { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        
        var pgHost = Environment.GetEnvironmentVariable("POSTGRES_HOST");
        var pgPort = Environment.GetEnvironmentVariable("POSTGRES_PORT");
        var pgUser = Environment.GetEnvironmentVariable("POSTGRES_USER");
        var pgPass = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
        var pgDb = Environment.GetEnvironmentVariable("POSTGRES_NAME");

        if (pgHost == null || pgPort == null || pgUser == null || pgPass == null || pgDb == null)
        {
            throw new EnvironmentVariableNotFoundException(nameof(pgHost), nameof(pgPort), 
                nameof(pgUser), nameof(pgPass), nameof(pgDb));
        }

        var connStr = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb};";
        optionsBuilder.UseNpgsql(connStr);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}