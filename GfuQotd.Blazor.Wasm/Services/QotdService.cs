using GfuQotd.Shared.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
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

        public async Task<bool> AddAuthorAsync(AuthorForCreateViewModel authorForCreateViewModel)
        {
            _logger.LogInformation($"Zu sendendes Model: {authorForCreateViewModel.LogAsJson()}");

            var formValues = new List<KeyValuePair<string, string>>
            {
                new("Name", authorForCreateViewModel.Name),
                new("Description", authorForCreateViewModel.Description)
            };

            //Falls Geburtsdatum vorhanden
            if(authorForCreateViewModel.BirthDate.HasValue)
                formValues.Add(new KeyValuePair<string, string>("BirthDate", authorForCreateViewModel.BirthDate.Value.ToString("O")));

            var multipartContent = new MultipartFormDataContent();
            formValues.ForEach(c => multipartContent.Add(new StringContent(c.Value), c.Key));

            //Bild vorhanden
            if (authorForCreateViewModel.Photo is not null)
            {
                var fileContent = new StreamContent(authorForCreateViewModel.Photo.OpenReadStream());
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(authorForCreateViewModel.Photo.ContentType);
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "Photo",
                    FileName = authorForCreateViewModel.Photo.Name
                };

                multipartContent.Add(fileContent);
            }

            //_logger.LogInformation($"Zu Multipart Model: {multipartContent.LogAsJson()}");

            var response = await _client.PostAsync(QotdAuthorsUri, multipartContent);
            response.EnsureSuccessStatusCode();

            _logger.LogInformation("Autor erfolgreich hinzugefügt");

            return response.IsSuccessStatusCode;
        }

        public async Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayWithApiKeyAsync()
        {
            //_client.DefaultRequestHeaders.Add("x-api-key", _appSettings.XApiKey);
            return await _client.GetFromJsonAsync<QuoteOfTheDayViewModel>(QotdRandomSecuredUri);
        }
    }
}
