using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GfuQotd.Shared.Model
{
    public class AuthorViewModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateOnly? BirthDate { get; set; }
        public IList<QuoteViewModel> Quotes { get; set; } = new List<QuoteViewModel>();
        public byte[]? Photo { get; set; }
        public string? PhotoMimeType { get; set; }
    }
}
