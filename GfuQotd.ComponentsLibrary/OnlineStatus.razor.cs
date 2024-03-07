using System.Numerics;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace GfuQotd.ComponentsLibrary;
public partial class OnlineStatus : IAsyncDisposable
{
    private string _bgColor = string.Empty;
    [Inject] public IJSRuntime JsRuntime { get; set; } = default!;
    private IJSObjectReference _jsModule = default!;
    private bool _isOnline;
    [Inject] public ILogger<OnlineStatus> Logger { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        Logger.LogInformation($"OnAfterRender wird aufgerufen...");

        if (firstRender)
        {
            var dotNetObjRef = DotNetObjectReference.Create(this);
            _jsModule = await JsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/GfuQotd.ComponentsLibrary/OnlineStatus.razor.js");
            await _jsModule.InvokeVoidAsync("registerOnlineStatusHandler", dotNetObjRef);
        }
    }

    [JSInvokable]
    public void SetOnlineStatusColor(bool isOnline)
    {
        _isOnline = isOnline;
        _bgColor = isOnline ? "bg-success" : "bg-danger";
        StateHasChanged();
    }

    public async ValueTask DisposeAsync()
    {
        if(_jsModule is not null) await _jsModule.DisposeAsync();
    }
}
