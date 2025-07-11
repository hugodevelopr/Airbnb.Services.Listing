using Airbnb.AppService.Commands.Listings.CreateListing;
using FluentValidation;

namespace Airbnb.AppService.Validations.Listings;

public class CreateListingValidator : AbstractValidator<CreateListingCommand>
{
    public CreateListingValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithCustomMessage("");
    }
}