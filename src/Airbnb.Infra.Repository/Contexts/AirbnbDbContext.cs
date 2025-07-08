using Airbnb.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.Infra.Repository.Contexts;

public class AirbnbDbContext : DbContext
{
    /// <inheritdoc />
    public AirbnbDbContext(DbContextOptions<AirbnbDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AirbnbDbContext).Assembly);

        ApplyGenericSettings(modelBuilder);
    }

    private static void ApplyGenericSettings(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var clrType = entityType.ClrType;
            if (typeof(BaseEntity).IsAssignableFrom(clrType))
            {
                modelBuilder.Entity(clrType).Ignore("Version");
            }
        }
    }
}