using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using GfuQotd.Shared.Model;
using Microsoft.AspNetCore.WebUtilities;

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

    public async Task<AuthorViewModel?> GetAuthorByIdAsync(Guid id, bool includeQuotes = false)
    {
        //return await client.GetFromJsonAsync<IEnumerable<AuthorViewModel>>($"{QotdAuthorsUri}/{id}?includeQuotes={includeQuotes}");

        var queryStringParam = new Dictionary<string, string>
        {
            ["includeQuotes"] = includeQuotes.ToString()
        };

        var response = await client.GetAsync(QueryHelpers.AddQueryString($"{QotdAuthorsUri}/{id}", queryStringParam!));

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<AuthorViewModel>();
    }
}