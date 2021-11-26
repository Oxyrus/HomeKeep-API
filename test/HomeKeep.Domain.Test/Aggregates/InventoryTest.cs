using FluentAssertions;
using HomeKeep.Domain.Aggregates;
using Xunit;

namespace HomeKeep.Domain.Test.Aggregates
{
    public class InventoryTest
    {
        [Fact]
        public void AddItem_Works()
        {
            // Arrange
            var inventory = new Inventory("Home");

            // Act
            inventory.AddItem("Butter", 1);

            // Assert
            inventory.Items
                .Count
                .Should()
                .Be(1);

            inventory.Items
                .Should()
                .Contain(i => i.Name == "Butter" && i.Quantity == 1);
        }
    }
}