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
    }
}