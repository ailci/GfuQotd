using GfuQotd.Service;
using GfuQotd.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace GfuQotd.Web.Blazor.Client.Pages.Author;
public partial class Index
{
    [Inject] public IQotdService QotdService { get; set; } = default!;
    private IEnumerable<AuthorViewModel>? AuthorsVm { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await GetAuthors();
    }

    public async Task GetAuthors()
    {
        AuthorsVm = await QotdService.GetAuthorsAsync();
    }
}
