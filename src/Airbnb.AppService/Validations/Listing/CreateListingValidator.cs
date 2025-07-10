using Airbnb.AppService.Commands.Listing.CreateListing;
using FluentValidation;

namespace Airbnb.AppService.Validations.Listing;

public class CreateListingValidator : AbstractValidator<CreateListingCommand>
{
    public CreateListingValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithCustomMessage("");
    }
}