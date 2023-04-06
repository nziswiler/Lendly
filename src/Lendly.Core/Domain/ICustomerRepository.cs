using Lendly.Core.Domain.Model;

namespace Lendly.Core.Domain
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetAll();

        Customer? GetByVisibleIdentifierOrDefault(int visibleIdentifier);
    }
}
