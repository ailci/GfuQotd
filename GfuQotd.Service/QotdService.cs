using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using GfuQotd.Shared.Model;

namespace GfuQotd.Service;

public class QotdService(HttpClient client) : IQotdService
{
    private const string QotdUri = "authors/quotes/random";
    private const string QotdAuthorsUri = "authors";

    public async Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayAsync()
    {
        return await client.GetFromJsonAsync<QuoteOfTheDayViewModel>(QotdUri);
    }

    public async Task<IEnumerable<AuthorViewModel>?> GetAuthorsAsync()
    {
        return await client.GetFromJsonAsync<IEnumerable<AuthorViewModel>>(QotdAuthorsUri);
    }
}