using Airbnb.AppService.Responses.Listing;
using Airbnb.Core.Commands;
using Airbnb.Core.Services;
using Airbnb.SharedKernel;
using Airbnb.SharedKernel.Common;

namespace Airbnb.AppService.Commands.Listing.CreateListing;

public class CreateListingCommandHandler : ICommandHandler<CreateListingCommand, Result<CreateListingResponse>>
{
    private readonly IListingService _listingService;

    public CreateListingCommandHandler(IListingService listingService)
    {
        _listingService = listingService;
    }

    public async Task<Result<CreateListingResponse>> HandleAsync(CreateListingCommand command)
    {
        command.NotNull(nameof(command));

        var response = new CreateListingResponse();

        return Result.Ok(response);
    }
}