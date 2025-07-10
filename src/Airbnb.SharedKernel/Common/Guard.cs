namespace Airbnb.SharedKernel.Common;

public static class Guard
{
    public static void NotNull(this object obj, string paramName)
    {
        if(obj == null)
            throw new ArgumentNullException(paramName, $"{paramName} cannot be null.");
    }
}