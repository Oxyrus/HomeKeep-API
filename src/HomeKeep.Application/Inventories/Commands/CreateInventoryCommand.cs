using HomeKeep.Application.Common.Interfaces;
using HomeKeep.Domain.Aggregates;
using MediatR;

namespace HomeKeep.Application.Inventories.Commands;

public sealed class CreateInventoryCommand : IRequest<Guid>
{
    public string Name { get; init; }
}

public sealed class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateInventoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
    {
        var inventory = new Inventory(request.Name);

        _context.Inventories.Add(inventory);
        await _context.SaveChangesAsync(cancellationToken);

        return inventory.Id;
    }
}
