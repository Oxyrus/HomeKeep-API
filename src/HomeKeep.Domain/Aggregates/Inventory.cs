using System;
using System.Collections.Generic;

namespace HomeKeep.Domain.Aggregates
{
    public sealed class Inventory
    {
        private readonly Guid _id;
        private readonly List<Item> _items = new();

        private Inventory(Guid id, string name)
        {
            _id = id;
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
}