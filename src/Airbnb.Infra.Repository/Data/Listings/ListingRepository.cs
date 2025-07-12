using Airbnb.Core.Entities;
using Airbnb.Core.Repositories;
using Airbnb.SharedKernel.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Airbnb.Infra.Repository.Data.Listings;

public class ListingRepository : BaseRepository, IListingRepository
{
    private readonly ILogger<ListingRepository> _logger;

    /// <inheritdoc />
    public ListingRepository(IConfiguration configuration, ILogger<ListingRepository> logger)
        : base(configuration)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task AddAsync(Listing listing)
    {
        await using var conn = new SqlConnection(ConnectionString);

        try
        {
            const string sql = """
                               
                               """;

            await conn.OpenAsync();
            await conn.ExecuteAsync(sql, new { listing });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
        finally
        {
            await conn.CloseAsync();
        }
    }

    public async Task<Listing?> GetByIdAsync(Guid listingId)
    {
        await using var conn = new SqlConnection(ConnectionString);

        try
        {
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
        finally
        {
            await conn.CloseAsync();
        }
    }

    public async Task UpdateAsync(Listing listing)
    {
        await using var conn = new SqlConnection(ConnectionString);

        try
        {
            const string sql = """

                               """;

            await conn.OpenAsync();
            await conn.ExecuteAsync(sql, new { listing });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
        finally
        {
            await conn.CloseAsync();
        }
    }
}