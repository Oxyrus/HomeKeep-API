using System;

namespace HomeKeep.Domain.Aggregates
{
    public sealed class Item
    {
        private readonly Guid _id;

        private Item(Guid id, string name, uint quantity)
        {
            _id = id;
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
}