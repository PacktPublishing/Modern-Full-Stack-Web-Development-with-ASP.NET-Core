using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Chapter6.Client;

internal static class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        await builder.Build().RunAsync();
    }
}
