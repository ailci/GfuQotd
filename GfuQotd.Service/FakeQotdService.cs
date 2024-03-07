using GfuQotd.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GfuQotd.Service;

public class FakeQotdService : IQotdService
{
    public Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayAsync()
    {
        var qotd = new QuoteOfTheDayViewModel
        ( 
            QuoteText: "bla blubb", 
            AuthorName: "Ich", 
            AuthorDescription: "Dozent",
            AuthorBirthdate: new DateOnly(1978, 07, 13),
            AuthorPhoto: null,
            AuthorPhotoMimeType: null
        );

        return Task.FromResult(qotd);
    }

    public Task<IEnumerable<AuthorViewModel>?> GetAuthorsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AuthorViewModel?> GetAuthorByIdAsync(Guid id, bool includeQuotes = false)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAuthorAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddAuthorAsync(AuthorForCreationViewModel authorForCreationViewModel)
    {
        throw new NotImplementedException();
    }
}