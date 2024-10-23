using GfuQotd.Blazor.Wasm.Pages.Author;
using GfuQotd.Blazor.Wasm.Services;
using GfuQotd.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Qotd.Components.Library.Components;

namespace GfuQotd.Blazor.Wasm.Components.Author;
public partial class AuthorTable
{
    [Inject] public ILogger<AuthorTable> Logger { get; set; } = default!;

    [Parameter, EditorRequired] 
    public IEnumerable<AuthorViewModel>? AuthorViewModels { get; set; }

    [Parameter] public EventCallback<Guid> OnAuthorDelete { get; set; }

    //[Inject] public IJSRuntime JsRuntime { get; set; } = default!;
    [Inject] public DialogService DialogService { get; set; } = default!;
    private ConfirmDialog? _confirmDialogComponent;
    private Guid _authorIdToDelete;

    private async Task DeleteAuthor(AuthorViewModel authorVm)
    {
        Logger.LogInformation($"AuthorId lautet: {authorVm.Id}");

        _authorIdToDelete = authorVm.Id;

        // 1. Version aufpassen confirmDialog nicht exportieren und index.html registrieren
        //if (await JsRuntime.InvokeAsync<bool>("confirmDialog", $"Wollen Sie wirklich den Autor '{authorVm?.Name}' löschen?"))
        //{
        //    await OnAuthorDelete.InvokeAsync(authorVm.Id); //Ereignis ausgelöst
        //}

        // 2. Version als DialogService
        //if (await DialogService.ConfirmAsync($"Wollen Sie wirklich den Autor '{authorVm?.Name}' löschen?"))
        //{
        //    await OnAuthorDelete.InvokeAsync(authorVm.Id); //Ereignis ausgelöst
        //}

        // 3.Version
        
        _confirmDialogComponent?.Show($"Wollen Sie wirklich den Autor <strong>'{authorVm?.Name}'</strong> löschen?");
    }

    private async Task ConfirmDeleteClicked(bool deleteConfirmed)
    {
        if (deleteConfirmed && _authorIdToDelete != default)
        {
            await OnAuthorDelete.InvokeAsync(_authorIdToDelete); //Ereignis ausgelöst
        }
    }
}
