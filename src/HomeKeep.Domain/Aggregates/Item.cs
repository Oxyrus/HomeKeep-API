namespace HomeKeep.Domain.Aggregates;

public sealed class Item
{
    public Guid Id { get; init; }

    private Item() { }

    private Item(Guid id, string name, uint quantity)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
    }

    internal Item(string name, uint quantity)
    {
        Name = name;
        Quantity = quantity;
    }

    public string Name { get; }

    public uint Quantity { get; }
}