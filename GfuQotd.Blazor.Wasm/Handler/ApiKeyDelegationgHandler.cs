using Microsoft.Extensions.Options;

namespace GfuQotd.Blazor.Wasm.Handler
{
    public class ApiKeyDelegationgHandler : DelegatingHandler
    {
        private readonly QotdAppSettings _appSettings;

        public ApiKeyDelegationgHandler(IOptions<QotdAppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("x-api-key", _appSettings.XApiKey);
            return base.SendAsync(request, cancellationToken);
        }
    }
}
