using GfuQotd.Shared.Model;

namespace GfuQotd.Blazor.Wasm.Pages;
public partial class Home
{
    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }

    //protected override void OnInitialized()
    //{
    //    QotdViewModel = new QuoteOfTheDayViewModel("Larum lierum L�ffelstiel", "Ich", "Dozent",
    //        DateOnly.FromDateTime(DateTime.Now), null, null);
    //}
}
