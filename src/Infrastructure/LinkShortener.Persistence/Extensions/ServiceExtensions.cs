using LinkShortener.Domain.Interfaces;
using LinkShortener.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LinkShortener.Persistence.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureRepositoryContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RepositoryContext>(options =>
        {
            options.UseMySQL(configuration.GetConnectionString("Database")!, builder => builder.MigrationsAssembly(nameof(Persistence)));
        });

        return services;
    }

    public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}