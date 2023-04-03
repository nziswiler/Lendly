using Lendly.Core.Domain;
using Lendly.Core.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Lendly.Infrastructure.DbAccess.Domain
{
    public class Repository<T> : IRepository<T>
        where T : EntityBase
    {
        private readonly DbSet<T> _set;

        public Repository(DbSet<T> set)
        {
            _set = set;
        }

        public IEnumerable<T> Get()
        {
            return _set;
        }

        public T GetById(Guid id)
        {
            return GetQuery().First(e => e.Id == id);
        }

        public T GetByIdOrDefault(Guid id)
        {
            return GetQuery().FirstOrDefault(e => e.Id == id);
        }

        public void Add(T add)
        {
            _set.Add(add);
        }

        public void Remove(T remove)
        {
            _set.Remove(remove);
        }

        protected virtual IQueryable<T> GetQuery()
        {
            return _set;
        }
    }
}
