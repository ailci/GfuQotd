using GfuQotd.Shared.Model;

namespace GfuQotd.Blazor.Wasm.Pages;
public partial class Home
{
    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }

    //protected override void OnInitialized()
    //{
    //    QotdViewModel = new QuoteOfTheDayViewModel("Larum lierum Löffelstiel", "Ich", "Dozent",
    //        DateOnly.FromDateTime(DateTime.Now), null, null);
    //}
}
