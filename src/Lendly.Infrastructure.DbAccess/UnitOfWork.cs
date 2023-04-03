using Lendly.Core;
using Lendly.Core.Domain;
using Lendly.Core.Domain.Model;
using Lendly.Infrastructure.DbAccess.Domain;

namespace Lendly.Infrastructure.DbAccess
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private IBookRepository bookRepository;
        private ICustomerRepository customerRepository;
        private ICategoryRepository categoryRepository;
        private ILoanRepository loanRepository;

        public UnitOfWork()
        {
            _context = new Context();
        }

        public IBookRepository BookRepository
        {
            get
            {
                if(this.bookRepository == null)
                {
                    this.bookRepository = new BookRepository(_context.Set<Book>());
                }

                return this.bookRepository;
            }
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (this.customerRepository == null)
                {
                    this.customerRepository = new CustomerRepository(_context.Set<Customer>());
                }

                return this.customerRepository;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new CategoryRepository(_context.Set<Category>());
                }

                return this.categoryRepository;
            }
        }

        public ILoanRepository LoanRepository
        {
            get
            {
                if (this.loanRepository == null)
                {
                    this.loanRepository = new LoanRepository(_context.Set<Loan>());
                }

                return this.loanRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
