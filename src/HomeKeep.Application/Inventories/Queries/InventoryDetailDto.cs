namespace HomeKeep.Application.Inventories.Queries;

public class InventoryDetailDto
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public IEnumerable<InventoryDetailItemDto> Items { get; init; }

    public class InventoryDetailItemDto
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public uint Quantity { get; init; }

        public bool Purchased { get; init; }
    }
}