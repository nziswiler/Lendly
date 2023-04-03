namespace Lendly.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
