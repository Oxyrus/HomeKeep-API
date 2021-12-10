using HomeKeep.Application.Common.Interfaces;
using HomeKeep.Domain.Aggregates;

namespace HomeKeep.Infrastructure.Persistence;

public class QueryableDbContext : IQueryableDbContext
{
    private readonly PostgreSqlContext _context;

    public QueryableDbContext(PostgreSqlContext context)
    {
        _context = context;
    }

    public IQueryable<Inventory> Inventories
    {
        get
        {
            return _context.Inventories;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}