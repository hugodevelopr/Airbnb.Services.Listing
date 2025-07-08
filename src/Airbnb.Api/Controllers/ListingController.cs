using Airbnb.AppService.Commands.Listing.CreateListing;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.Api.Controllers;

[ApiController]
[Route("api/listings")]
public class ListingController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateListing([FromBody] CreateListingCommand command)
    {
        return Ok();
    }
}