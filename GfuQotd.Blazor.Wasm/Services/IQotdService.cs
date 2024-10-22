using GfuQotd.Shared.Model;

namespace GfuQotd.Blazor.Wasm.Services
{
    public interface IQotdService
    {
        Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayAsync();
        Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayWithApiKeyAsync();
        Task<IEnumerable<AuthorViewModel>?> GetAuthorAsync();   
        Task<bool> DeleteAuthorAsync(Guid authorId);
    }
}
