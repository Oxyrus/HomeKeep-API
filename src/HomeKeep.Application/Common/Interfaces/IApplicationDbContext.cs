using HomeKeep.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace HomeKeep.Application.Common.Interfaces;

/// <summary>
/// Used exclusively to write to the database using the root aggregates
/// </summary>
public interface IApplicationDbContext
{
    DbSet<Inventory> Inventories { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}