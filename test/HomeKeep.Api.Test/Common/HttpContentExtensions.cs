using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HomeKeep.Api.Test.Common;

internal static class HttpContentExtensions
{
    internal static async Task<T?> Deserialize<T>(this HttpContent httpContent)
    {
        var json = await httpContent.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
    }
}