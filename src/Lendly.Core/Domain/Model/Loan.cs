namespace Lendly.Core.Domain.Model
{
    public class Loan : EntityBase
    {
        // VisibleIdentifier is used for a better usability in the CommandLine.
        // Remove it when implementing the real user interface.
        public int VisibleIdentifier { get; set; }

        public DateTime StartOfLoan { get; set; }

        public DateTime? EndOfLoan { get; set; }

        public Guid BookId { get; set; }

        public Guid CustomerId { get; set; }

        public Book Book { get; set; }

        public Customer Customer { get; set; }
    }
}
