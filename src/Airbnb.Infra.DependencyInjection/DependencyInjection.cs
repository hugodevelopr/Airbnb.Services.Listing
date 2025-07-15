using Airbnb.AppService;
using Airbnb.Core;
using Airbnb.Infra.Broker;
using Airbnb.Infra.Broker.Publisher;
using Airbnb.Infra.Repository;
using Airbnb.Infra.Repository.Contexts;
using Airbnb.SharedKernel.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Airbnb.Infra.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddAirbnbDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AirbnbDbContext>(options =>
        {
            options.EnableDetailedErrors();
            options.UseSqlServer(configuration.GetConnectionString("AirbnbDb"), sqlOptions =>
            {
                sqlOptions.MigrationsAssembly("Airbnb.Api");
                sqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", "Airbnb");
            });
        });

        services.AddAppService();
        services.AddCore();
        services.AddRepository(configuration);
        services.AddBroker();

        services.AddSingleton<AuditPublisherDelegate>(sp =>
        {
            var publisher = sp.GetRequiredService<IEventPublisher>();
            return message => publisher.PublishAsync(message, "audit-requests");
        });

        return services;
    }
}