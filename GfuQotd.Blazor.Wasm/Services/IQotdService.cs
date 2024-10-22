using GfuQotd.Shared.Model;

namespace GfuQotd.Blazor.Wasm.Services
{
    public interface IQotdService
    {
        Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayAsync();
        Task<IEnumerable<AuthorViewModel>?> GetAuthorAsync();
    }
}
