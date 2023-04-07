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

        public IEnumerable<Book> GetAll()
        {
            return this.GetQuery()
                .Include(e => e.Category)
                .OrderBy(e => e.VisibleIdentifier);
        }

        public Book? GetByVisibleIdentifierOrDefault(int visibleIdentifier)
        {
            return this.GetQuery()
                .Include(e => e.Category)
                .FirstOrDefault(e => e.VisibleIdentifier.Equals(visibleIdentifier));
        }

        public bool IsCategoryUsed(string category)
        {
            return this.GetAll().FirstOrDefault(e => e.Category.Name.Trim().ToLower() == category.Trim().ToLower()) != null;
        }
    }
}
