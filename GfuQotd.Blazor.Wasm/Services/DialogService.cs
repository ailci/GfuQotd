using Microsoft.JSInterop;

namespace GfuQotd.Blazor.Wasm.Services
{
    public class DialogService(IJSRuntime jsRuntime) : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> _moduleTask = new(() =>
            jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/dialog.js").AsTask());

        public async Task<bool> ConfirmAsync(string message)
        {
            var module = await _moduleTask.Value; //JS-Datei als Modul 
            return await module.InvokeAsync<bool>("confirmDialog", message); //Aufruf einer Funktion
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
}
