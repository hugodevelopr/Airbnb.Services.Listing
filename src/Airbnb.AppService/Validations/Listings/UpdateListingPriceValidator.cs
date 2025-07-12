using Airbnb.AppService.Commands.Listings.UpdateListingPrice;
using FluentValidation;

namespace Airbnb.AppService.Validations.Listings;

public class UpdateListingPriceValidator : AbstractValidator<UpdateListingPriceCommand>
{
    public UpdateListingPriceValidator()
    {
    }
}