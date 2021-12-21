using System.Collections.Generic;
using System.Linq;
using HomeKeep.Api.Test.Common;
using HomeKeep.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HomeKeep.Api.Test;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        var dbConnection = BaseIntegrationTest.Configuration().GetSection("ConnectionStrings:Default");
        builder.ConfigureAppConfiguration((_, configurationBuilder) =>
        {
            /*
            configurationBuilder.AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    ["ConnectionStrings:Default"] = dbConnection.Value
                });
                */
            configurationBuilder.AddInMemoryCollection(BaseIntegrationTest.Configuration().AsEnumerable());
        });

        builder.ConfigureServices(s =>
        {
            var descriptor = s.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
        });

        base.ConfigureWebHost(builder);
    }
}