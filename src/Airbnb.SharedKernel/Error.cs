namespace Airbnb.SharedKernel;

[Serializable]
public class Error(string code, string message)
{
    public Error()
        : this(string.Empty, string.Empty)
    {
    }

    public string Code { get; } = code;
    public string Message { get; } = message;
}