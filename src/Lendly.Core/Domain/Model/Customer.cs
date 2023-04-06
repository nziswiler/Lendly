namespace Lendly.Core.Domain.Model
{
    public class Customer : EntityBase
    {
        // VisibleIdentifier is used for a better usability in the CommandLine. Remove it when implementing the real user interface.
        public int VisibleIdentifier { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}
