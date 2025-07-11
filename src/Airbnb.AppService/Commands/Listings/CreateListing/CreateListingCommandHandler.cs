using Airbnb.AppService.Responses.Listings;
using Airbnb.AppService.Validations;
using Airbnb.AppService.Validations.Listings;
using Airbnb.Core.Commands;
using Airbnb.Core.Entities;
using Airbnb.Core.Services;
using Airbnb.SharedKernel;
using Airbnb.SharedKernel.Common;
using AutoMapper;

namespace Airbnb.AppService.Commands.Listings.CreateListing;

public class CreateListingCommandHandler : ICommandHandler<CreateListingCommand, Result<CreateListingResponse>>
{
    private readonly IListingService _listingService;
    private readonly IMapper _mapper;

    public CreateListingCommandHandler(IListingService listingService, IMapper mapper)
    {
        _listingService = listingService;
        _mapper = mapper;
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

        var listing = new Listing();
        listing.Create();

        var changes = listing.GetChanges();

        foreach (var change in changes)
        {
            //TODO: save to events
        }

        response = _mapper.Map<CreateListingResponse>(response);

        return Result.Ok(response);
    }
}