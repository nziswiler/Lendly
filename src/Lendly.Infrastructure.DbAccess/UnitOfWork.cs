using Lendly.Core;
using Lendly.Core.Domain;
using Lendly.Core.Domain.Model;
using Lendly.Infrastructure.DbAccess.Domain;

namespace Lendly.Infrastructure.DbAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private bool _isDisposed;

        private IBookRepository bookRepository;
        private ICustomerRepository customerRepository;
        private ICategoryRepository categoryRepository;
        private ILoanRepository loanRepository;

        public UnitOfWork()
        {
            _context = new Context();
        }

        public IBookRepository BookRepository => this.bookRepository ?? new BookRepository(_context.Set<Book>());
        public ICustomerRepository CustomerRepository => this.customerRepository ?? new CustomerRepository(_context.Set<Customer>());
        public ICategoryRepository CategoryRepository => this.categoryRepository ?? new CategoryRepository(_context.Set<Category>());
        public ILoanRepository LoanRepository => this.loanRepository ?? new LoanRepository(_context.Set<Loan>());

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing && !_isDisposed)
            {
                _isDisposed = true;
                _context.Dispose();
            }
        }
    }
}
