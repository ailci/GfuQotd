using GfuQotd.Shared.Model;
using Microsoft.AspNetCore.Components;

namespace GfuQotd.Blazor.Wasm.Components.Author;
public partial class AuthorTable
{
    [Inject] public ILogger<AuthorTable> Logger { get; set; } = default!;

    [Parameter, EditorRequired] 
    public IEnumerable<AuthorViewModel>? AuthorViewModels { get; set; }

    [Parameter] public EventCallback<Guid> OnAuthorDelete { get; set; }

    private async Task DeleteAuthor(AuthorViewModel authorVm)
    {
        Logger.LogInformation($"AuthorId lautet: {authorVm.Id}");

        await OnAuthorDelete.InvokeAsync(authorVm.Id); //Ereignis ausgelöst

    }
}
