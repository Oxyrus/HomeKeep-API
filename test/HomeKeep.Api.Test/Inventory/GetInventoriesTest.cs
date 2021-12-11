using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using HomeKeep.Api.Test.Common;
using Xunit;

namespace HomeKeep.Api.Test.Inventory;

[Collection("Inventories")]
public class GetInventoriesTest : BaseIntegrationTest
{
    public GetInventoriesTest(CustomWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetInventories_Works()
    {
        // Act
        var response = await Client.GetAsync("api/Inventory");

        // Assert
        response.EnsureSuccessStatusCode();

        response.StatusCode
            .Should()
            .Be(HttpStatusCode.OK);
    }
}