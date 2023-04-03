using Lendly.Core.Domain;
using Lendly.Core.Domain.Model;

using Microsoft.EntityFrameworkCore;

namespace Lendly.Infrastructure.DbAccess.Domain
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(DbSet<Book> set) 
            : base(set)
        {
        }
    }
}
