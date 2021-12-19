using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using HomeKeep.Api.Test.Common;
using HomeKeep.Application.Inventories.Commands;
using HomeKeep.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HomeKeep.Api.Test.Inventory;

[Collection("Inventories")]
public class CreateInventoryTest : BaseIntegrationTest
{
    public CreateInventoryTest(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task CreateInventory_Works()
    {
        // Arrange
        var inventory = new CreateInventoryCommand
        {
            Name = "Home"
        };
        var json = JsonSerializer.Serialize(inventory);

        // Act
        var response = await Client.PostAsync("api/Inventory", new StringContent(json, Encoding.UTF8, "application/json"));

        // Assert
        response.EnsureSuccessStatusCode();

        var createdInventory = await Context.Inventories
            .FirstOrDefaultAsync(i => i.Name == inventory.Name);

        createdInventory
            .Should()
            .NotBeNull();
    }
}