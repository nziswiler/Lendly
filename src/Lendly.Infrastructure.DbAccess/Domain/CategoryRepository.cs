using Lendly.Core.Domain;
using Lendly.Core.Domain.Model;

using Microsoft.EntityFrameworkCore;

namespace Lendly.Infrastructure.DbAccess.Domain
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbSet<Category> set) 
            : base(set)
        {
        }

        public Category? GetByNameOrDefault(string name)
        {
            return this.GetQuery().FirstOrDefault(e => e.Name.Trim().ToLower() == name.Trim().ToLower());
        }

        public IEnumerable<Category> GetByKeyword(string keyword)
        {
            return this.GetQuery().Where(e => e.Name.Trim().ToLower().Contains(keyword.Trim().ToLower()));
        }
    }
}
