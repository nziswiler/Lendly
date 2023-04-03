﻿namespace Lendly.Core.Domain.Model
{
    public class Customer : EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}
