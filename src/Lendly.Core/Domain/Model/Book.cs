namespace Lendly.Core.Domain.Model
{
    public class Book : EntityBase
    {
        // VisibleIdentifier is used for a better usability in the CommandLine.
        // Remove it when implementing the real user interface.
        public int VisibleIdentifier { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}
