using System.Text.Json.Serialization;
using Airbnb.AppService.Responses.Listings;
using Airbnb.Core.Commands;
using Airbnb.SharedKernel;

namespace Airbnb.AppService.Commands.Listings.CreateListing;

public sealed class CreateListingCommand : ICommand<Result<CreateListingResponse>>, IUserScopedCommand
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    [JsonIgnore]
    public Guid UserId { get; set; }
}