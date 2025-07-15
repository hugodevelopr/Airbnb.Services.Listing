using Airbnb.Api.Infrastructure.Controllers;
using Airbnb.AppService.Commands.Listings.CreateListing;
using Airbnb.AppService.Commands.Listings.UpdateListingPrice;
using Airbnb.Core.Commands;
using Airbnb.SharedKernel;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.Api.Controllers;

[Route("api/listings")]
public class ListingController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;

    /// <inheritdoc />
    public ListingController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> CreateListing([FromBody] CreateListingCommand command)
    {
        var result = await _commandDispatcher.DispatchAsync(command);

        if (result.IsSuccess)
            return await Created(result);
        
        return Error(ErrorCode.FailedToCreateListing, result.Errors);
    }

    [HttpPut("{listingId:guid}/price")]
    public async Task<IActionResult> UpdatePrice([FromRoute] Guid listingId, [FromBody] UpdateListingPriceCommand command)
    {
        command.ListingId = listingId;

        var result = await _commandDispatcher.DispatchAsync(command);

        if (result.IsSuccess)
            return Ok(result);

        return Error(ErrorCode.FailedToUpdateListingPrice, result.Errors);
    }
}