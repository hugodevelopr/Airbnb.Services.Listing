using Airbnb.Core.Repositories;
using Airbnb.Infra.Repository.Data.Listings;
using Airbnb.Infra.Repository.Data.System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Airbnb.Infra.Repository;

public static class Extensions
{
    public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IListingRepository, ListingRepository>();
        services.AddScoped<ILocalizeMessageRepository, LocalizeMessageRepository>();

        return services;
    }
}