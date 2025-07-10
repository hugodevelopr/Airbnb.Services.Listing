using Airbnb.AppService.Responses.Listing;
using Airbnb.Core.Commands;
using Airbnb.SharedKernel;

namespace Airbnb.AppService.Commands.Listing.CreateListing;

public sealed class CreateListingCommand : ICommand<Result<CreateListingResponse>>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}