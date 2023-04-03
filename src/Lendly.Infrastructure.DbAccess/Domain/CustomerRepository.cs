using Lendly.Core.Domain;
using Lendly.Core.Domain.Model;

using Microsoft.EntityFrameworkCore;

namespace Lendly.Infrastructure.DbAccess.Domain
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbSet<Customer> set) 
            : base(set)
        {
        }
    }
}
