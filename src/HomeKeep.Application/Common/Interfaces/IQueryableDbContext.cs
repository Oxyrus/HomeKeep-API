using HomeKeep.Domain.Aggregates;

namespace HomeKeep.Application.Common.Interfaces;

public interface IQueryableDbContext : IDisposable
{
    IQueryable<Inventory> Inventories();
}