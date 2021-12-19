using HomeKeep.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeKeep.Application.Items.Commands;

public sealed class MarkItemAsPurchasedCommand : IRequest
{
    public Guid InventoryId { get; init; }

    public Guid ItemId { get; init; }
}

public sealed class MarkItemAsPurchasedCommandHandler : AsyncRequestHandler<MarkItemAsPurchasedCommand>
{
    private readonly IApplicationDbContext _context;

    public MarkItemAsPurchasedCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    protected override async Task Handle(MarkItemAsPurchasedCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new InvalidOperationException();

        var inventory = await _context.Inventories
            .Include(i => i.Items)
            .SingleOrDefaultAsync(i => i.Id == request.InventoryId, cancellationToken);

        if (inventory is null)
            throw new InvalidOperationException("Inventory not found");

        var item = inventory.Items.SingleOrDefault(i => i.Id == request.ItemId);
        inventory.MarkItemAsPurchased(item);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
