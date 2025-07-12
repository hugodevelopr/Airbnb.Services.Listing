using Airbnb.AppService.Responses.Listings;
using Airbnb.AppService.Validations;
using Airbnb.AppService.Validations.Listings;
using Airbnb.Core.Commands;
using Airbnb.Core.Entities;
using Airbnb.Core.Repositories;
using Airbnb.Core.Services;
using Airbnb.Infra.Broker.EventSourcing;
using Airbnb.SharedKernel;
using Airbnb.SharedKernel.Common;
using AutoMapper;

namespace Airbnb.AppService.Commands.Listings.CreateListing;

public class CreateListingCommandHandler : ICommandHandler<CreateListingCommand, Result<CreateListingResponse>>
{
    private readonly IListingRepository _listingRepository;
    private readonly IMapper _mapper;
    private readonly IStoreEvent _storeEvent;

    public CreateListingCommandHandler(IListingRepository listingRepository, IMapper mapper, IStoreEvent storeEvent)
    {
        _listingRepository = listingRepository;
        _mapper = mapper;
        _storeEvent = storeEvent;
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

        await _listingRepository.AddAsync(listing);

        var changes = listing.GetChanges();

        foreach (var change in changes)
        {
            await _storeEvent.SaveEventAsync(change, listing.Id, command.UserId);
        }
        
        response = _mapper.Map<CreateListingResponse>(response);

        return Result.Ok(response);
    }
}