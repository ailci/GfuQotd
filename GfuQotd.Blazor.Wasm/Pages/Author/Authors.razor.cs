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
    [Inject] public NavigationManager NavManager { get; set; } = default!;

    #endregion

    protected override async Task OnInitializedAsync()
    {
        await GetAuthors();
    }

    private async Task GetAuthors()
    {
        AuthorsVm = (await QotdService.GetAuthorAsync())?.OrderBy(c => c.Name);
    }

    private async Task DeleteAuthor(Guid authorId)
    {
        Logger.LogInformation($"Eltern Komponente Löschen von Author-Id {authorId}...");

        var isAuthorDeleted = await QotdService.DeleteAuthorAsync(authorId);

        if (isAuthorDeleted)
        {
            await GetAuthors();
        }
        else
        {
            
        }
    }

    private void NavigateToNewAuthor()
    {
        NavManager.NavigateTo("/authors/new");
    }
}
