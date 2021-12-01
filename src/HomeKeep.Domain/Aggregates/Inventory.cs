namespace HomeKeep.Domain.Aggregates;

public sealed class Inventory
{
    public Guid Id { get; init; }
    private readonly List<Item> _items = new();

    private Inventory() { }

    private Inventory(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Inventory(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public IReadOnlyList<Item> Items => _items;

    public void AddItem(string name, uint quantity)
    {
        _items.Add(new Item(name, quantity));
    }
}