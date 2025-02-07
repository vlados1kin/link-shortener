using System.Reflection;
using LinkShortener.Application.Services;
using LinkShortener.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LinkShortener.Application.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }

    public static IServiceCollection ConfigureMediatr(this IServiceCollection services)
    {
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }

    public static IServiceCollection ConfigureShortUrlGenerator(this IServiceCollection services)
    {
        services.AddScoped<IShortUrlGenerator, ShortUrlGenerator>();

        return services;
    }
}