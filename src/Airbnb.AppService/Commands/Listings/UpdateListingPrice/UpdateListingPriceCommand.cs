using Airbnb.AppService.Responses.Listings;
using Airbnb.Core.Commands;
using Airbnb.SharedKernel;
using System.Text.Json.Serialization;

namespace Airbnb.AppService.Commands.Listings.UpdateListingPrice;

public class UpdateListingPriceCommand : ICommand<Result<UpdateListingPriceResponse>>, IUserScopedCommand
{
    public decimal NewPrice { get; set; }
    public string Currency { get; set; } = string.Empty;

    [JsonIgnore]
    public Guid ListingId { get; set; }

    [JsonIgnore]
    public Guid UserId { get; set; }
}