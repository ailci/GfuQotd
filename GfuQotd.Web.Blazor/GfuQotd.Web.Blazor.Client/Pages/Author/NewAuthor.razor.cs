using GfuQotd.Service;
using GfuQotd.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace GfuQotd.Web.Blazor.Client.Pages.Author;
public partial class NewAuthor
{
    #region Member

    [SupplyParameterFromForm] public AuthorForCreationViewModel? AuthorForCreationVm { get; set; }
    [Inject] private IQotdService QotdService { get; set; } = default!;
    [Inject] public NavigationManager NavigationManager { get; set; } = default!;
    private string? ErrorMessage { get; set; }

    #endregion

    protected override void OnInitialized()
    {
        AuthorForCreationVm ??= new AuthorForCreationViewModel();
    }

    private async Task HandleValidSubmit()
    {
        try
        {
            ErrorMessage = null;
            var success = await QotdService.AddAuthorAsync(AuthorForCreationVm);

            if (success)
            {
                NavigationManager.NavigateTo("/authors/overview");
            }

        }
        catch (Exception ex)
        {
            ErrorMessage = $"Ein Fehler ist aufgetreten: {ex.Message}";
        }
    }

    private void OnInputFileChanged(InputFileChangeEventArgs obj)
    {
        AuthorForCreationVm!.Photo = obj.File;
    }
}
