using System.Net.Http.Json;
using System.Text.Json;
using GfuQotd.Blazor.Wasm.Services;
using GfuQotd.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace GfuQotd.Blazor.Wasm.Pages;


public partial class Home
{
    [Inject] public ILogger<Home> Logger { get; set; } = default!;
    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }

    [Inject] public IHttpClientFactory HttpClientFactory { get; set; } = default!;

    [Inject] public IQotdService QotdService { get; set; } = default!;

    //protected override void OnInitialized()
    //{
    //    Logger.LogInformation("Home Componente aufgerufen...");

    //    QotdViewModel = new QuoteOfTheDayViewModel("Larum lierum Löffelstiel", "Ich", "Dozent",
    //        DateOnly.FromDateTime(DateTime.Now), null, null);
    //}

    protected override async Task OnInitializedAsync()
    {
        Logger.LogInformation("Home Componente aufgerufen...");

        // 1. Version Mit HttpClientFactory
        //using var client = HttpClientFactory.CreateClient("qotdapiservice");
        //var response = await client.GetAsync("authors/quotes/random");
        //response.EnsureSuccessStatusCode();
        //var json = await response.Content.ReadAsStringAsync();
        //Logger.LogInformation($"Response => {json}");
        //QotdViewModel = JsonSerializer.Deserialize<QuoteOfTheDayViewModel>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

        // 2. Version mit HttpClientFactory Abkürzung
        //using var client = HttpClientFactory.CreateClient("qotdapiservice");
        //QotdViewModel = await client.GetFromJsonAsync<QuoteOfTheDayViewModel>("authors/quotes/random");

        // 3. Version mit Service
        QotdViewModel = await QotdService.GetQuoteOfTheDayAsync();
    }
}
