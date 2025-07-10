using System.Text.Json.Serialization;

namespace Airbnb.SharedKernel.Responses;

public class BaseResponse : IValidatorResponse, IResponse
{
    protected BaseResponse()
    {
        Errors = new List<Error>();
    }
    
    public void AddError(string code, string message)
    {
        Errors.Add(new Error(code, message));
    }

    public void AddError(IList<Error> errors)
    {
        foreach(var error in errors)
            AddError(error.Code, error.Message);
    }

    [JsonIgnore]
    public bool IsSuccess => !Errors.Any();

    [JsonIgnore]
    public IList<Error> Errors { get; set; }
}