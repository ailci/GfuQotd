using GfuQotd.Shared.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace GfuQotd.Blazor.Wasm.Services
{
    public class QotdService : IQotdService
    {
        private readonly HttpClient _client;
        private const string QotdRandomUri = "authors/quotes/random";

        public QotdService(HttpClient client)
        {
            _client = client;
        }

        public async Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayAsync()
        {
            return await _client.GetFromJsonAsync<QuoteOfTheDayViewModel>(QotdRandomUri);
        }
    }
}
