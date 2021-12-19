namespace HomeKeep.Domain.Aggregates;

public sealed class Inventory
{
    private Inventory() { }

    public Inventory(string name)
    {
        Name = name;
    }

    public Guid Id { get; init; }

    public string Name { get; private set; }

    private readonly List<Item> _items = new();

    public IReadOnlyList<Item> Items => _items;

    public void AddItem(string name, uint quantity)
    {
        _items.Add(new Item(name, quantity));
    }

    public void MarkItemAsPurchased(Item item)
    {
        if (item is null)
            throw new InvalidOperationException("You must provide an item to be marked as purchased");

        var itemToBeMarkedAsPurchased = _items.SingleOrDefault(i => i == item);

        if (itemToBeMarkedAsPurchased is null)
            throw new InvalidOperationException("Could not find the specified item to mark it as purchased");

        itemToBeMarkedAsPurchased.MarkAsPurchased();
    }
}