using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GfuQotd.Shared.Model;

public record QuoteOfTheDayViewModel(string QuoteText, string AuthorName, string AuthorDescription,
    DateOnly? AuthorBirthdate, byte[]? AuthorPhoto, string? AuthorPhotoMimeType);