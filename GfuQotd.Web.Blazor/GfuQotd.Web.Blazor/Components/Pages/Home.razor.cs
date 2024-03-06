using System.Text.Json;
using GfuQotd.Service;
using GfuQotd.Shared;
using GfuQotd.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;

namespace GfuQotd.Web.Blazor.Components.Pages;
public partial class Home
{
    private readonly string _color = "text-primary";

    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }
    [Inject] public ILogger<Home> Logger { get; set; } = default!;
    [Inject] public IHttpClientFactory HttpClientFactory { get; set; } = default!;
    [Inject] public IQotdService QotdService { get; set; } = default!;
    [Inject(Key = "fakeservice")] public IQotdService FakeQotdService { get; set; } = default!;
    [Inject] public IOptions<QotdAppSettings> AppSettings { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        Logger.LogInformation("Home Componente aufgerufen...");

        //1. Version
        //using var client = HttpClientFactory.CreateClient("externalapiservice");
        //client.DefaultRequestHeaders.Add("x-api-key", AppSettings.Value.XApiKey);
        //var response = await client.GetAsync("authors/quotes/random"); // BaseAddress + Individuell
        //response.EnsureSuccessStatusCode();

        //var json = await response.Content.ReadAsStringAsync();
        //Logger.LogInformation(json);
        //QotdViewModel = JsonSerializer.Deserialize<QuoteOfTheDayViewModel>(json, 
        //    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        //2.Version
        //using var client = HttpClientFactory.CreateClient("externalapiservice");
        //QotdViewModel = await client.GetFromJsonAsync<QuoteOfTheDayViewModel>("authors/quotes/random");

        //3.Version mit QotdService
        QotdViewModel = await QotdService.GetQuoteOfTheDayAsync();
        //QotdViewModel = await FakeQotdService.GetQuoteOfTheDayAsync();

    }
}
