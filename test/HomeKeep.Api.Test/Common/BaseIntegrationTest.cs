using System.Net.Http;
using System.Threading.Tasks;
using HomeKeep.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Respawn;
using Xunit;

namespace HomeKeep.Api.Test.Common;

public class BaseIntegrationTest : IClassFixture<CustomWebApplicationFactory<Program>>, IAsyncLifetime
{
    private static readonly Checkpoint Checkpoint = new Checkpoint
    {
        SchemasToInclude = new[]
        {
            "public"
        },
        DbAdapter = DbAdapter.Postgres
    };

    protected readonly HttpClient Client;
    protected readonly CustomWebApplicationFactory<Program> Factory;
    protected readonly ApplicationDbContext Context;

    protected BaseIntegrationTest(CustomWebApplicationFactory<Program> factory)
    {
        Factory = factory;
        Client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });

        using var sp = Factory.Services.CreateScope();
        Context = sp.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }

    public virtual Task InitializeAsync() => Task.CompletedTask;

    /// <summary>
    /// Used to reset the database to a clean state so the data
    /// doesn't interfere between each test
    /// </summary>
    public virtual async Task DisposeAsync()
    {
        var dbConnection = Configuration().GetSection("ConnectionStrings:Default");

        await using var conn =
            new NpgsqlConnection(dbConnection.Value);

        await conn.OpenAsync();

        await Checkpoint.Reset(conn);
    }

    public static IConfiguration Configuration()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.test.json")
            .AddEnvironmentVariables()
            .Build();

        return config;
    }
}