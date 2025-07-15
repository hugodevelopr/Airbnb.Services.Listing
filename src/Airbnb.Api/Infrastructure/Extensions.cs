using Airbnb.Api.Infrastructure.Filters;
using Airbnb.Infra.DependencyInjection;
using Airbnb.SharedKernel;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;

namespace Airbnb.Api.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddAirbnb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddObservability(configuration);

        services.AddControllers(options =>
        {
            options.Filters.Add<UserContextInjectionFilter>();
        });

        services.AddOpenApi();
        services.AddAirbnbDependencies(configuration);
        return services;
    }

    public static IServiceCollection AddObservability(this IServiceCollection services, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .WriteTo.NewRelicLogs(
                licenseKey: configuration["NewRelic:LicenseKey"],
                endpointUrl: configuration["NewRelic:EndpointUrl"],
                applicationName: AirbnbSettings.ServiceName)
            .CreateLogger();

        services.AddOpenTelemetry()
            .WithTracing(traceProvider =>
            {
                traceProvider
                    .AddSource(AirbnbSettings.ServiceName)
                    .SetResourceBuilder(ResourceBuilder.CreateDefault()
                        .AddService(AirbnbSettings.ServiceName))
                    .AddOtlpExporter(options =>
                    {
                        options.Endpoint = new Uri(configuration["NewRelic:EndpointUrl"]!);
                        options.Headers = $"api-key={configuration["NewRelic:ApiKey"]}";
                    });
            });

        return services;
    }
}