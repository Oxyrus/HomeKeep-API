using HomeKeep.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeKeep.Application.Inventories.Queries;

public sealed class GetInventoriesQuery : IRequest<IEnumerable<InventoryDto>>
{
}

public sealed class GetInventoriesQueryHandler : IRequestHandler<GetInventoriesQuery, IEnumerable<InventoryDto>>
{
    private readonly IQueryableDbContext _queryableDbContext;

    public GetInventoriesQueryHandler(IQueryableDbContext queryableDbContext)
    {
        _queryableDbContext = queryableDbContext;
    }

    public async Task<IEnumerable<InventoryDto>> Handle(GetInventoriesQuery request, CancellationToken cancellationToken)
    {
        var inventories = await _queryableDbContext.Inventories.ToListAsync(cancellationToken);

        return inventories.Select(i => new InventoryDto
        {
            Id = i.Id,
            Name = i.Name
        });
    }
}