using HomeKeep.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeKeep.Application.Inventories.Queries;

public sealed class GetInventoryByIdQuery : IRequest<InventoryDto>
{
    public readonly Guid InventoryId;

    public GetInventoryByIdQuery(Guid inventoryId)
    {
        InventoryId = inventoryId;
    }
}

public sealed class GetInventoryByIdQueryHandler : IRequestHandler<GetInventoryByIdQuery, InventoryDto>
{
    private readonly IQueryableDbContext _context;

    public GetInventoryByIdQueryHandler(IQueryableDbContext context)
    {
        _context = context;
    }

    public async Task<InventoryDto> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new InvalidOperationException("Invalid request");

        var inventory = await _context.Inventories
            .SingleOrDefaultAsync(i => i.Id == request.InventoryId, cancellationToken);
        if (inventory is null)
            throw new InvalidOperationException("Could not find the specified inventory");

        return new InventoryDto
        {
            Id = inventory.Id
        };
    }
}
