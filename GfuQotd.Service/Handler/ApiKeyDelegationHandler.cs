using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GfuQotd.Shared;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GfuQotd.Service.Handler;

public class ApiKeyDelegationHandler(IOptions<QotdAppSettings> appSettings, ILogger<ApiKeyDelegationHandler> logger) 
    : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Delegating Handler mit ApiKey {appSettings.Value.XApiKey} aufgerufen...");
        request.Headers.Add("x-api-key", appSettings.Value.XApiKey);
        
        return base.SendAsync(request, cancellationToken);
    }
}