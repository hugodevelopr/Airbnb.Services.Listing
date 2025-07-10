namespace Airbnb.SharedKernel;

public static class ServiceLocator
{
    public static IServiceProvider Instance { get; private set; }

    public static void SetLocatorProvider(IServiceProvider serviceProvider)
    {
        Instance = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider), "Service provider cannot be null.");
    }
}