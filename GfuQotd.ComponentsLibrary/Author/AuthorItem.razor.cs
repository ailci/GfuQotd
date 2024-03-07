using GfuQotd.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace GfuQotd.ComponentsLibrary.Author;
public partial class AuthorItem
{
    [Inject] public ILogger<AuthorItem> Logger { get; set; } = default!;
    [Parameter] public AuthorViewModel? AuthorVm { get; set; }
    [Parameter] public EventCallback<Guid> OnAuthorDeleteEventCallback { get; set; }
    [Inject] public IJSRuntime JsRuntime { get; set; } = default!;
    [Inject] public DialogService DialogService { get; set; } = default!;


    private async Task DeleteAuthor(Guid authorId)
    {
        //Logger.LogInformation($"Author mit der Id {authorId} zum Löschen ausgewählt...");
        
        // 1. Version Klassik
        //if (await JsRuntime.InvokeAsync<bool>("confirm", $"Wollen Sie wirklich den Autor '{AuthorVm?.Name}' löschen?"))
        //{
        //    await OnAuthorDeleteEventCallback.InvokeAsync(authorId);
        //}

        // 2. Version DialogService als JS Modul
        if (await DialogService.ConfirmAsync($"Wollen Sie wirklich den Autor '{AuthorVm?.Name}' löschen?"))
        {
            await OnAuthorDeleteEventCallback.InvokeAsync(authorId);
        }
    }
}
