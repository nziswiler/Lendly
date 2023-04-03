using Lendly.Core.Domain.Model;

namespace Lendly.Core.Domain
{
    public interface IRepository<T>
        where T : EntityBase
    {
        IEnumerable<T> Get();

        T GetById(Guid id);

        T GetByIdOrDefault(Guid id);

        void Add(T add);

        void Remove(T remove);
    }
}
