using HomeKeep.Application.Common.Interfaces;
using HomeKeep.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HomeKeep.Infrastructure.Persistence;

public class PostgreSqlContext : DbContext, IApplicationDbContext
{
    private readonly IConfiguration _configuration;

    public PostgreSqlContext(
        DbContextOptions<PostgreSqlContext> options,
        IConfiguration configuration) : base(options)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(_configuration.GetSection("ConnectionStrings:Default").Value);

        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Inventory> Inventories { get; set; }
}