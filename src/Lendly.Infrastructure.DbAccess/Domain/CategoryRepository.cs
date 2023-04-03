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
    }
}
