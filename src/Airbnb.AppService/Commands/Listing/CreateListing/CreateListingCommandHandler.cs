using Airbnb.AppService.Responses.Listing;
using Airbnb.AppService.Validations;
using Airbnb.AppService.Validations.Listing;
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
        command.NotNullOrEmpty(nameof(command));

        var response = new CreateListingResponse();
        var validator = new CreateListingValidator();

        var validationResult = await validator.ValidateCommandAsync(command);
        response.AddError(validationResult.Errors);

        if (!response.IsSuccess)
            return Result.Fail<CreateListingResponse>(response.Errors)!;

        return Result.Ok(response);
    }
}