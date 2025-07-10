using Airbnb.Core.Services;
using Airbnb.SharedKernel;
using Airbnb.SharedKernel.Common;
using FluentValidation;
using FluentValidation.Internal;

namespace Airbnb.AppService.Validations;

public static class ValidationWrapper
{
    public static Result ValidateCommand<T>(this IValidator<T> validator, T instance,
        Action<ValidationStrategy<T>> options)
    {
        var result = validator.Validate(ValidationContext<T>.CreateWithOptions(instance, options));

        var errors = result.Errors
            .Select(failure => new Error(failure.ErrorCode, failure.ErrorMessage))
            .ToList();

        return errors.Any() ? Result.Fail(new List<Error>(errors)) : Result.Ok();
    }

    public static Result ValidateCommand<T>(this IValidator<T> validator, T instance)
    {
        var result = validator.Validate(new ValidationContext<T>(instance));

        var errors = result.Errors
            .Select(failure => new Error(failure.ErrorCode, failure.ErrorMessage))
            .ToList();

        return errors.Any() ? Result.Fail(new List<Error>(errors)) : Result.Ok();
    }

    public static async Task<Result> ValidateCommandAsync<T>(this IValidator<T> validator, T instance)
    {
        var result = await validator.ValidateAsync(new ValidationContext<T>(instance));

        var errors = result.Errors
            .Select(failure => new Error(failure.ErrorCode, failure.ErrorMessage))
            .ToList();

        return errors.Any() ? Result.Fail(new List<Error>(errors)) : Result.Ok();
    }

    public static IRuleBuilderOptions<T, TProperty> WithCustomMessage<T, TProperty>(
        this IRuleBuilderOptions<T, TProperty> rule, string keyMessage)
    {
        keyMessage.NotNullOrEmpty(nameof(keyMessage));

        var localizeMessageService = ServiceLocator.Instance.GetService(typeof(ILocalizeMessageService)) as ILocalizeMessageService;

        var localize = localizeMessageService?.GetMessageAsync(keyMessage).GetAwaiter().GetResult();

        return localize == null
            ? throw new InvalidOperationException($"Unregistered key {keyMessage}")
            : rule
                .WithErrorCode(localize.Key)
                .WithMessage(localize.MessageTemplate);
    }
}