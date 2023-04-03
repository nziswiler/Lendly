namespace Lendly.Core.Domain.Model
{
    public class Loan : EntityBase
    {
        public DateTime StartOfLoan { get; set; }

        public DateTime? EndOfLoan { get; set; }

        public Guid BookId { get; set; }

        public Guid CustomerId { get; set; }

        public Book Book { get; set; }

        public Customer Customer { get; set; }
    }
}
