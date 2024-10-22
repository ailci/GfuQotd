using GfuQotd.Shared.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace GfuQotd.Blazor.Wasm.Services
{
    public class QotdService : IQotdService
    {
        private readonly ILogger<QotdService> _logger;
        private readonly HttpClient _client;
        private const string QotdRandomUri = "authors/quotes/random";
        private const string QotdAuthorsUri = "authors";

        public QotdService(HttpClient client, ILogger<QotdService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayAsync()
        {
            return await _client.GetFromJsonAsync<QuoteOfTheDayViewModel>(QotdRandomUri);
        }

        public async Task<IEnumerable<AuthorViewModel>?> GetAuthorAsync()
        {
            var authorsVm = await _client.GetFromJsonAsync<IEnumerable<AuthorViewModel>>(QotdAuthorsUri);
            
            _logger.LogInformation(authorsVm.ToString());

            return authorsVm;
        }
    }
}
