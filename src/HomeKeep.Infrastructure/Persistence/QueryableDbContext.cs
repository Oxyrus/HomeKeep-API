using HomeKeep.Application.Common.Interfaces;
using HomeKeep.Domain.Aggregates;

namespace HomeKeep.Infrastructure.Persistence;

public class QueryableDbContext : IQueryableDbContext
{
    private readonly ApplicationDbContext _context;

    public QueryableDbContext(ApplicationDbContext context)
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