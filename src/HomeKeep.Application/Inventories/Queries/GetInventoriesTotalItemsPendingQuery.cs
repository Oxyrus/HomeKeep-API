using HomeKeep.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeKeep.Application.Inventories.Queries;

public sealed class GetInventoriesTotalItemsPendingQuery : IRequest<InventoryTotalItemsPendingDto>
{
}

public sealed class GetInventoriesTotalItemsPendingQueryHandler : IRequestHandler<GetInventoriesTotalItemsPendingQuery, InventoryTotalItemsPendingDto>
{
    private readonly IQueryableDbContext _context;

    public GetInventoriesTotalItemsPendingQueryHandler(IQueryableDbContext context)
    {
        _context = context;
    }

    public async Task<InventoryTotalItemsPendingDto> Handle(GetInventoriesTotalItemsPendingQuery request, CancellationToken cancellationToken)
    {
        var inventories = await _context.Inventories
            .Include(i => i.Items.Where(it => !it.Purchased))
            .ToListAsync(cancellationToken);

        var totalItemsPendingToBePurchased = inventories.Sum(i => i.Items.Count);

        return new InventoryTotalItemsPendingDto(totalItemsPendingToBePurchased);
    }
}
