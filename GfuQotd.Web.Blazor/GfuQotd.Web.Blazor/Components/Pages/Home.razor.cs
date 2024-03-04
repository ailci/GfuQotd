using GfuQotd.Shared.Model;

namespace GfuQotd.Web.Blazor.Components.Pages;
public partial class Home
{
    private readonly string _color = "text-primary";

    public QuoteOfTheDayViewModel? QotdViewModel { get; set; }
}
