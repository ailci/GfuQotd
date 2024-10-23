using GfuQotd.Blazor.Wasm;
using GfuQotd.Blazor.Wasm.Handler;
using GfuQotd.Blazor.Wasm.Pages;
using GfuQotd.Blazor.Wasm.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Config-Datei Options-Pattern
builder.Services.Configure<QotdAppSettings>(builder.Configuration.GetSection("QotdAppSettings"));

//HttpClient Named Client
//builder.Services.AddHttpClient("qotdapiservice", opt =>
//{
//    opt.BaseAddress = new Uri("https://qotdminimalapi.azurewebsites.net");
//});

//DI
builder.Services.AddScoped<IQotdService, QotdService>();
builder.Services.AddScoped<DialogService>();

//HttpClient Typed Version
builder.Services.AddScoped<ApiKeyDelegationgHandler>();
builder.Services.AddHttpClient<IQotdService, QotdService>((sp,opt) =>
{
    //opt.BaseAddress = new Uri(builder.Configuration["QotdAppSettings:QotdApiBaseAddress"]);
    var apiConfiguration = sp.GetRequiredService<IOptions<QotdAppSettings>>().Value;
    opt.BaseAddress = new Uri(apiConfiguration.QotdApiBaseAddress);
    //opt.DefaultRequestHeaders.Add("x-api-key", apiConfiguration.XApiKey);
    opt.DefaultRequestHeaders.Add("Accept", "application/json");
})
    .AddHttpMessageHandler<ApiKeyDelegationgHandler>();

await builder.Build().RunAsync();
