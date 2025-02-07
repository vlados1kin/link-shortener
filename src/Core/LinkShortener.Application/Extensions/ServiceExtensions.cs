using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using LinkShortener.Application.Services;
using LinkShortener.Application.Validators;
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

    public static IServiceCollection ConfigureValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<UrlRequestDtoValidator>();

        return services;
    }
}