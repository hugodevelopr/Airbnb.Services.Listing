namespace Airbnb.SharedKernel.Responses;

public interface IValidatorResponse
{
    bool IsSuccess { get; }
    void AddError(string code, string message);
    void AddError(IList<Error> errors);
    IList<Error> Errors { get; set; }
}