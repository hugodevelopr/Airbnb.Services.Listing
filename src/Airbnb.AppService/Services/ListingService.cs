using Airbnb.Core.Repositories;
using Airbnb.Core.Services;
using Airbnb.SharedKernel.Services;

namespace Airbnb.AppService.Services;

internal class ListingService(IListingRepository listingRepository) : BaseService, IListingService
{
}