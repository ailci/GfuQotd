using Microsoft.JSInterop;

namespace GfuQotd.ComponentsLibrary;
// This class provides an example of how JavaScript functionality can be wrapped
// in a .NET class for easy consumption. The associated JavaScript module is
// loaded on demand when first needed.
//
// This class can be registered as scoped DI service and then injected into Blazor
// components for use.

public class DialogService(IJSRuntime jsRuntime) : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
        "import", "./_content/GfuQotd.ComponentsLibrary/dialog.js").AsTask());

    public async ValueTask<bool> ConfirmAsync(string message)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<bool>("showConfirm", message);
    }

    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}