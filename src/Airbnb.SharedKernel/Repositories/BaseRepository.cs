using Microsoft.Extensions.Configuration;

namespace Airbnb.SharedKernel.Repositories;

public abstract class BaseRepository(IConfiguration configuration)
{
    protected string? ConnectionString { get; } = configuration.GetConnectionString("AirbnbDb");
}