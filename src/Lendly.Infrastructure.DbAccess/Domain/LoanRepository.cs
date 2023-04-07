using Lendly.Core.Domain;
using Lendly.Core.Domain.Model;

using Microsoft.EntityFrameworkCore;

namespace Lendly.Infrastructure.DbAccess.Domain
{
    public class LoanRepository : Repository<Loan>, ILoanRepository
    {
        public LoanRepository(DbSet<Loan> set) 
            : base(set)
        {
        }

        public IEnumerable<Loan> GetAllPending()
        {
            return this.GetQuery()
                .Include(e => e.Customer)
                .Include(e => e.Book)
                .Where(e => e.EndOfLoan == null)
                .OrderBy(e => e.VisibleIdentifier);
        }

        public IEnumerable<Loan> GetByCustomerId(int customerId)
        {
            return this.GetQuery()
                .Include(e => e.Customer)
                .Include(e => e.Book)
                .Where(e => e.Customer.VisibleIdentifier == customerId)
                .OrderBy(e => e.VisibleIdentifier);
        }

        public IEnumerable<Loan> GetByBookId(int bookId)
        {
            return this.GetQuery()
                .Include(e => e.Customer)
                .Include(e => e.Book)
                .Where(e => e.Book.VisibleIdentifier == bookId)
                .OrderBy(e => e.VisibleIdentifier);
        }

        public Loan? GetPendingOrDefaultByBookId(int bookId)
        {
            return this.GetAllPending().FirstOrDefault(e => e.VisibleIdentifier == bookId);
        }
    }
}
