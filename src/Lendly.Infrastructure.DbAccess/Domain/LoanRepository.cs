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
    }
}
