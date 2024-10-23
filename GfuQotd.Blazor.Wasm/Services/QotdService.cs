using GfuQotd.Shared.Model;
using System.Net.Http;
using System.Net.Http.Json;
using GfuQotd.Blazor.Wasm.Utilities;
using Microsoft.Extensions.Options;

namespace GfuQotd.Blazor.Wasm.Services
{
    public class QotdService : IQotdService
    {
        private readonly ILogger<QotdService> _logger;
        private readonly HttpClient _client;
        private readonly QotdAppSettings _appSettings;
        private const string QotdRandomUri = "authors/quotes/random";
        private const string QotdRandomSecuredUri = "authors/quotes/randomsecured";
        private const string QotdAuthorsUri = "authors";

        public QotdService(HttpClient client, ILogger<QotdService> logger, IOptions<QotdAppSettings> appSettings)
        {
            _client = client;
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        public async Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayAsync()
        {
            return await _client.GetFromJsonAsync<QuoteOfTheDayViewModel>(QotdRandomUri);
        }

        public async Task<IEnumerable<AuthorViewModel>?> GetAuthorAsync()
        {
            var authorsVm = await _client.GetFromJsonAsync<IEnumerable<AuthorViewModel>>(QotdAuthorsUri);
            
            //_logger.LogInformation(authorsVm?.LogAsJson());

            return authorsVm;
        }

        public async Task<bool> DeleteAuthorAsync(Guid authorId)
        {
            _logger.LogInformation($"DeleteAuthor aufgerufen mit Author-Id => {authorId}...");

            var response = await _client.DeleteAsync($"{QotdAuthorsUri}/{authorId}");

            if (!response.IsSuccessStatusCode)
            {
                var statusCode = (int) response.StatusCode;
                var reasonPhrase = response.ReasonPhrase;
                throw new Exception($"Fehler von der API: {statusCode} {reasonPhrase}");
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayWithApiKeyAsync()
        {
            //_client.DefaultRequestHeaders.Add("x-api-key", _appSettings.XApiKey);
            return await _client.GetFromJsonAsync<QuoteOfTheDayViewModel>(QotdRandomSecuredUri);
        }
    }
}
