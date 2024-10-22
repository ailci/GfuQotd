namespace GfuQotd.Shared.Model
{
    public class QuoteViewModel
    {
        public Guid Id { get; set; }
        public required string QuoteText { get; set; }
    }
}