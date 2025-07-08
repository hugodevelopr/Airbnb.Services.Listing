using Airbnb.AppService.Commands.Listing.CreateListing;
using Airbnb.Core.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.Api.Controllers;

[ApiController]
[Route("api/listings")]
public class ListingController : ControllerBase
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
        return Ok();
    }
}