using Microsoft.AspNetCore.Components;

namespace Qotd.Components.Library.Components;
public partial class ConfirmDialog
{
    [Parameter] public EventCallback<bool> OnDeleteConfirm { get; set; }
    [Parameter] public string ConfirmTitle { get; set; } = string.Empty;
    [Parameter] public string ConfirmMessage { get; set; } = "Sind Sie sicher?";
    private bool _isVisible;
    private MarkupString _convertedConfirmMessage;

    protected override void OnInitialized()
    {
        _convertedConfirmMessage = new MarkupString(ConfirmMessage);
    }

    public void Show()
    {
        _isVisible = true;
        StateHasChanged();
    }
    
    public void Show(string message)
    {
        _isVisible = true;
        ConfirmMessage = message;
        _convertedConfirmMessage = new MarkupString(ConfirmMessage);
        StateHasChanged();
    }

    private async Task OnConfirmChange(bool deleteConfirmed)
    {
        _isVisible = false;

        if (deleteConfirmed)
        {
            await OnDeleteConfirm.InvokeAsync(deleteConfirmed);
        }
    }
}
