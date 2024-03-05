using GfuQotd.Web.Blazor.Client.Configuration;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//Konfiguration
builder.Services.AddQotdConfig(builder.Configuration)
    .AddApiServicesConfig()
    .AddHttpClientsConfig(builder.Configuration);

await builder.Build().RunAsync();
