using Airbnb.AppService.Responses.Listing;
using Airbnb.Core.Commands;
using Airbnb.SharedKernel;

namespace Airbnb.AppService.Commands.Listing.CreateListing;

public sealed class CreateListingCommand : ICommand<Result<CreateListingResponse>>
{

}