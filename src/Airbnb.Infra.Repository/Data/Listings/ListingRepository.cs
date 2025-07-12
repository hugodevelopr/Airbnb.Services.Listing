using Airbnb.Core.Entities;
using Airbnb.Core.Repositories;
using Airbnb.SharedKernel.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Airbnb.Infra.Repository.Data.Listings;

public class ListingRepository : BaseRepository, IListingRepository
{
    /// <inheritdoc />
    public ListingRepository(IConfiguration configuration)
        : base(configuration)
    {
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
            throw;
        }
        finally
        {
            await conn.CloseAsync();
        }
    }
}