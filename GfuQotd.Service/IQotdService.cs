using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GfuQotd.Shared.Model;

namespace GfuQotd.Service;

public interface IQotdService
{
    Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayAsync();
    Task<IEnumerable<AuthorViewModel>?> GetAuthorsAsync();
    Task<AuthorViewModel?> GetAuthorByIdAsync(Guid id, bool includeQuotes = false);
    Task<bool> DeleteAuthorAsync(Guid id);
    Task<bool> AddAuthorAsync(AuthorForCreationViewModel authorForCreationViewModel);
}