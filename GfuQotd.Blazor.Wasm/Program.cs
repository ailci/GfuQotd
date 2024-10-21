using GfuQotd.Blazor.Wasm;
using GfuQotd.Blazor.Wasm.Pages;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//HttpClient Named Client
builder.Services.AddHttpClient("qotdapiservice", opt =>
{
    opt.BaseAddress = new Uri("https://qotdminimalapi.azurewebsites.net");
});



//DI


await builder.Build().RunAsync();
