using Airbnb.Core.Entities;

namespace Airbnb.Core.Repositories;

public interface IListingRepository
{
    Task AddAsync(Listing listing);
    Task<Listing?> GetByIdAsync(Guid listingId);
    Task UpdateAsync(Listing listing);
}