using HomeKeep.Application.Common.Interfaces;
using HomeKeep.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeKeep.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Here it would be possible to add a different provider based on a configuration
        // for instance, for the integration tests you probably want to use a different
        // database than the one you're using for development
        services.AddDbContext<PostgreSqlContext>(options =>
        {
            options.UseNpgsql(configuration.GetSection("ConnectionStrings:Default").Value, builder =>
            {
                builder.MigrationsAssembly(typeof(PostgreSqlContext).Assembly.FullName);
            });
        });

        services.AddScoped<IQueryRunner, PostgreSqlQueryRunner>();

        return services;
    }
}