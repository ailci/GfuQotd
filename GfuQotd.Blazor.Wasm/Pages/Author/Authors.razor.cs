using GfuQotd.Blazor.Wasm.Services;
using GfuQotd.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace GfuQotd.Blazor.Wasm.Pages.Author;
public partial class Authors
{
    #region Members

    [Inject] public ILogger<Authors> Logger { get; set; } = default!;
    [Inject] public IQotdService QotdService { get; set; } = default!;
    public IEnumerable<AuthorViewModel>? AuthorsVm { get; set; }

    #endregion

    protected override async Task OnInitializedAsync()
    {
        await GetAuthors();
    }

    private async Task GetAuthors()
    {
        AuthorsVm = await QotdService.GetAuthorAsync();
    }
}
