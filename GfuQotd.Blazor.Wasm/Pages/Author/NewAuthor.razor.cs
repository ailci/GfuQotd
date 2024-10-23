using GfuQotd.Blazor.Wasm.Services;
using GfuQotd.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace GfuQotd.Blazor.Wasm.Pages.Author;
public partial class NewAuthor
{
    [Inject] public ILogger<NewAuthor> Logger { get; set; } = default!;
    public AuthorForCreateViewModel? AuthorForCreateVm { get; set; }
    [Inject] public IQotdService QotdService { get; set; } = default!;
    [Inject] public NavigationManager NavManager { get; set; } = default!;

    protected override void OnInitialized() => AuthorForCreateVm ??= new();

    private async Task HandleValidSubmit(EditContext arg)
    {
        var success = await QotdService.AddAuthorAsync(AuthorForCreateVm);

        if (success)
        {
            NavManager.NavigateTo("/authors/overview");
        }
    }

    private void OnInputFileChange(InputFileChangeEventArgs e)
    {
        AuthorForCreateVm!.Photo = e.File;
    }
}
