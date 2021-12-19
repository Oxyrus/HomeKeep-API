namespace HomeKeep.Domain.Aggregates;

public sealed class Item
{
    private Item() { }

    internal Item(string name, uint quantity, bool purchased = false)
    {
        Name = name;
        Quantity = quantity;
        Purchased = purchased;
    }

    public Guid Id { get; init; }

    public string Name { get; private set;  }

    public uint Quantity { get; private set; }

    public bool Purchased { get; private set; }

    internal void MarkAsPurchased()
    {
        Purchased = true;
    }
}