using Lendly.Core.Domain.Model;

namespace Lendly.Core.Domain
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category? GetByNameOrDefault(string name);

        IEnumerable<Category> GetByKeyword(string keyword);
    }
}
