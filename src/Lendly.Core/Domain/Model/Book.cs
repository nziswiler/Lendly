namespace Lendly.Core.Domain.Model
{
    public class Book : EntityBase
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public string ISBN { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}
