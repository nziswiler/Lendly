using Lendly.Core.Domain.Model;

namespace Lendly.Core.Domain
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetAll();

        Book? GetByVisibleIdentifierOrDefault(int visibleIdentifier);

        bool IsCategoryUsed(string category);
    }
}
