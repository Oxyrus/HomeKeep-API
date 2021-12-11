namespace HomeKeep.Domain.Aggregates;

public sealed class Item
{
    public Guid Id { get; init; }

    public string Name { get; }

    public uint Quantity { get; }

    private Item() { }

    internal Item(string name, uint quantity)
    {
        Name = name;
        Quantity = quantity;
    }
}