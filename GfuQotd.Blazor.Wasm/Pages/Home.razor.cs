using GfuQotd.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace GfuQotd.Blazor.Wasm.Pages;
public partial class Home
{
    [Inject] public ILogger<Home> Logger { get; set; } = default!;
    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }

    //protected override void OnInitialized()
    //{
    //    Logger.LogInformation("Home Componente aufgerufen...");

    //    QotdViewModel = new QuoteOfTheDayViewModel("Larum lierum Löffelstiel", "Ich", "Dozent",
    //        DateOnly.FromDateTime(DateTime.Now), null, null);
    //}
}
