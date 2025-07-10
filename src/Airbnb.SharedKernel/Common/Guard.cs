namespace Airbnb.SharedKernel.Common;

public static class Guard
{
    public static void NotNullOrEmpty(this string str, string paramName)
    {
        if (string.IsNullOrEmpty(str))
            throw new ArgumentException($"{paramName} cannot be null or empty.", paramName);
    }

    public static void NotNullOrEmpty(this object obj, string paramName)
    {
        if (obj == null)
            throw new ArgumentException($"{paramName} cannot be null or empty.", paramName);
    }
}