using System.Text.Json.Serialization;
using Airbnb.AppService.Responses.Listings;
using Airbnb.Core.Commands;
using Airbnb.SharedKernel;

namespace Airbnb.AppService.Commands.Listings.UpdateListingPrice;

public class UpdateListingPriceCommand : ICommand<Result<UpdateListingPriceResponse>>, IUserScopedCommand
{
    public Guid ListingId { get; set; }
    public decimal NewPrice { get; set; }
    public string Currency { get; set; } = string.Empty;

    [JsonIgnore]
    public Guid UserId { get; set; }
}