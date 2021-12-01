using HomeKeep.Application.Common.Interfaces;
using MediatR;

namespace HomeKeep.Application.Inventories.Queries;

public sealed class GetInventoriesQuery : IRequest<IReadOnlyList<InventoryDto>>
{
}

public sealed class GetInventoriesQueryHandler : IRequestHandler<GetInventoriesQuery, IReadOnlyList<InventoryDto>>
{
    private readonly IQueryRunner _queryRunner;

    public GetInventoriesQueryHandler(IQueryRunner queryRunner)
    {
        _queryRunner = queryRunner;
    }

    public async Task<IReadOnlyList<InventoryDto>> Handle(GetInventoriesQuery request, CancellationToken cancellationToken)
    {
        var sql = @"
SELECT
    I.""Id""
FROM ""Inventories"" I
";

        var inventories = await _queryRunner.QueryMultipleAsync<InventoryDto>(sql);

        return inventories as IReadOnlyList<InventoryDto> ?? Array.Empty<InventoryDto>();
    }
}