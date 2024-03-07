using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

    public async Task<bool> DeleteAuthorAsync(Guid id)
    {
        var response = await client.DeleteAsync($"authors/{id}");

        response.EnsureSuccessStatusCode();

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> AddAuthorAsync(AuthorForCreationViewModel authorForCreationViewModel)
    {
        var values = new List<KeyValuePair<string, string>>
        {
            new("Name", authorForCreationViewModel.Name),
            new("Description", authorForCreationViewModel.Description)
        };

        if (authorForCreationViewModel.BirthDate.HasValue)
        {
            values.Add(new KeyValuePair<string, string>("BirthDate", authorForCreationViewModel.BirthDate.Value.ToString("O"))); //Ansonsten Fehler Tausch von Monat und Tag
        }

        var multipartContent = new MultipartFormDataContent();
        values.ForEach(c => multipartContent.Add(new StringContent(c.Value), c.Key));

        //Bild vorhanden
        if (authorForCreationViewModel.Photo is not null)
        {
            var fileContent = new StreamContent(authorForCreationViewModel.Photo.OpenReadStream());
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(authorForCreationViewModel.Photo.ContentType);
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "Photo",
                FileName = authorForCreationViewModel.Photo.Name
            };
            multipartContent.Add(fileContent);
        }

        var response = await client.PostAsync(QotdAuthorsUri, multipartContent);

        response.EnsureSuccessStatusCode();

        return response.IsSuccessStatusCode;
    }
}