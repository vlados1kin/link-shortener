using LinkShortener.Domain.Interfaces;
using LinkShortener.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using Polly;

namespace LinkShortener.Persistence.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureRepositoryContext(this IServiceCollection services, IConfiguration configuration)
    {
        var retryPolicy = Policy
            .Handle<MySqlException>()
            .WaitAndRetry(5, duration => TimeSpan.FromSeconds(Math.Pow(2, duration)));
        
        services.AddDbContext<RepositoryContext>(options =>
        {
            retryPolicy.Execute(() => options.UseMySql(
                configuration.GetConnectionString("Database"), 
                ServerVersion.AutoDetect(configuration.GetConnectionString("Database"))
                ));
        });

        return services;
    }

    public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}