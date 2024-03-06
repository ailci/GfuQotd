using GfuQotd.ComponentsLibrary.Author;
using GfuQotd.Service;
using GfuQotd.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace GfuQotd.Web.Blazor.Client.Pages.Author;
public partial class Index
{
    [Inject] public ILogger<Index> Logger { get; set; } = default!;
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

    private async Task DeleteAuthor(Guid authorId)
    {
        Logger.LogInformation($"Author mit der Id {authorId} zum Löschen in ElternKomponente ausgewählt...");

        var success = await QotdService.DeleteAuthorAsync(authorId);

        if (success)
        {
            //TODO: Benachrichtigung
            Logger.LogInformation("Author wurde gelöscht...");
            await GetAuthors();
        }
        else
        {
            //TODO: Fehlerbenachrichtigung
        }
    }
}
