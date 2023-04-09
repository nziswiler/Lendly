using Lendly.Core.Domain.Model;

namespace Lendly.Core.Domain
{
    public interface ILoanRepository : IRepository<Loan>
    {
        IEnumerable<Loan> GetAllPending();

        IEnumerable<Loan> GetByCustomerId(int customerId);

        IEnumerable<Loan> GetByBookId(int bookId);

        Loan? GetPendingOrDefaultByBookId(int bookId);
    }
}
