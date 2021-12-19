using HomeKeep.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeKeep.Application.Items.Commands;

public class CreateItemCommand : IRequest<Guid>
{
    public Guid InventoryId { get; init; }

    public string Name { get; init; }

    public uint Quantity { get; init; }
}

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new InvalidOperationException();

        var inventory = await _context.Inventories
            .Include(i => i.Items)
            .SingleOrDefaultAsync(i => i.Id == request.InventoryId, cancellationToken);

        if (inventory is null)
            throw new InvalidOperationException("Inventory not found");

        inventory.AddItem(request.Name, request.Quantity);

        await _context.SaveChangesAsync(cancellationToken);

        return inventory.Id;
    }
}
