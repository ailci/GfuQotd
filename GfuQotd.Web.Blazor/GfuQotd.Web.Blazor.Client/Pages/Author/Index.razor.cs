using GfuQotd.ComponentsLibrary.Author;
using GfuQotd.Service;
using GfuQotd.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace GfuQotd.Web.Blazor.Client.Pages.Author;
public partial class Index
{
    [Inject] public ILogger<Index> Logger { get; set; } = default!;
    [Inject] public IQotdService QotdService { get; set; } = default!;
    [Inject] public NavigationManager NavigationManager { get; set; } = default!;
    private IEnumerable<AuthorViewModel>? AuthorsVm { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await GetAuthors();
    }

    public async Task GetAuthors()
    {
        AuthorsVm = await QotdService.GetAuthorsAsync();
    }

    private async Task DeleteAuthor(Guid authorId)
    {
        Logger.LogInformation($"Author mit der Id {authorId} zum L�schen in ElternKomponente ausgew�hlt...");

        var success = await QotdService.DeleteAuthorAsync(authorId);

        if (success)
        {
            //TODO: Benachrichtigung
            Logger.LogInformation("Author wurde gel�scht...");
            await GetAuthors();
        }
        else
        {
            //TODO: Fehlerbenachrichtigung
            //throw new Exception("Author konnte nicht gel�scht werden");
        }
    }

    private void NavigateToAuthorNew()
    {
        NavigationManager.NavigateTo("/authors/new");
    }
}
