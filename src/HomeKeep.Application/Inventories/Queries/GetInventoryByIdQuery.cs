using HomeKeep.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeKeep.Application.Inventories.Queries;

public sealed class GetInventoryByIdQuery : IRequest<InventoryDetailDto>
{
    public readonly Guid InventoryId;

    public GetInventoryByIdQuery(Guid inventoryId)
    {
        InventoryId = inventoryId;
    }
}

public sealed class GetInventoryByIdQueryHandler : IRequestHandler<GetInventoryByIdQuery, InventoryDetailDto>
{
    private readonly IQueryableDbContext _context;

    public GetInventoryByIdQueryHandler(IQueryableDbContext context)
    {
        _context = context;
    }

    public async Task<InventoryDetailDto> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new InvalidOperationException("Invalid request");

        var inventory = await _context.Inventories
            .Include(i => i.Items.Where(item => !item.Purchased))
            .SingleOrDefaultAsync(i => i.Id == request.InventoryId, cancellationToken);

        if (inventory is null)
            throw new InvalidOperationException("Could not find the specified inventory");

        return new InventoryDetailDto
        {
            Id = inventory.Id,
            Name = inventory.Name,
            Items = inventory.Items.Select(i => new InventoryDetailDto.InventoryDetailItemDto
            {
                Id = i.Id,
                Name = i.Name,
                Purchased = i.Purchased,
                Quantity = i.Quantity
            })
        };
    }
}
