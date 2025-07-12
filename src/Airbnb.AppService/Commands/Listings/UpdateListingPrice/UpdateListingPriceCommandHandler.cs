using Airbnb.AppService.Responses.Listings;
using Airbnb.AppService.Validations;
using Airbnb.AppService.Validations.Listings;
using Airbnb.Core.Commands;
using Airbnb.Core.Repositories;
using Airbnb.Infra.Broker.EventSourcing;
using Airbnb.SharedKernel;
using Airbnb.SharedKernel.Common;
using AutoMapper;

namespace Airbnb.AppService.Commands.Listings.UpdateListingPrice;

public class UpdateListingPriceCommandHandler : ICommandHandler<UpdateListingPriceCommand, Result<UpdateListingPriceResponse>>
{
    private readonly IListingRepository _listingRepository;
    private readonly IMapper _mapper;
    private readonly IStoreEvent _storeEvent;

    public UpdateListingPriceCommandHandler(IListingRepository listingRepository, IMapper mapper, IStoreEvent storeEvent)
    {
        _listingRepository = listingRepository;
        _mapper = mapper;
        _storeEvent = storeEvent;
    }

    public async Task<Result<UpdateListingPriceResponse>> HandleAsync(UpdateListingPriceCommand command)
    {
        command.NotNullOrEmpty(nameof(command));

        var response = new UpdateListingPriceResponse();
        var validator = new UpdateListingPriceValidator();

        var validationResult = await validator.ValidateCommandAsync(command);
        response.AddError(validationResult.Errors);

        if (!response.IsSuccess)
            return Result.Fail<UpdateListingPriceResponse>(response.Errors)!;

        var listing = await _listingRepository.GetByIdAsync(command.ListingId);

        listing!.UpdatePrice(command.NewPrice, command.Currency);

        await _listingRepository.UpdateAsync(listing);

        var changes = listing.GetChanges();

        foreach (var change in changes)
        {
            await _storeEvent.SaveEventAsync(change, listing.Id, command.UserId);
        }

        response = _mapper.Map<UpdateListingPriceResponse>(response);

        return Result.Ok(response);
    }
}