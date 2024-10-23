using GfuQotd.Shared.Model;
using Microsoft.AspNetCore.Components.Forms;

namespace GfuQotd.Blazor.Wasm.Pages.Author;
public partial class NewAuthor
{
    public AuthorForCreateViewModel? AuthorForCreateVm { get; set; }

    protected override void OnInitialized() => AuthorForCreateVm ??= new();

    private Task HandleValidSubmit(EditContext arg)
    {
        return Task.CompletedTask;
    }
}
