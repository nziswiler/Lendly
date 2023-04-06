using Lendly.Core.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Lendly.Infrastructure.DbAccess
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Lendly;Trusted_Connection=True;TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Book>()
                .Property(e => e.VisibleIdentifier)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Book>()
                .HasOne(e => e.Category)
                .WithMany(e => e.Books)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Customer>()
                .Property(e => e.VisibleIdentifier)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Loan>().HasKey(e => e.Id); 
            modelBuilder.Entity<Loan>()
                .Property(e => e.VisibleIdentifier)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Loan>()
                .HasOne(e => e.Book)
                .WithMany(e => e.Loans)
                .HasForeignKey(e => e.BookId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Loan>()
                .HasOne(e => e.Customer)
                .WithMany(e => e.Loans)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>()
                .HasKey(e => e.Id);
        }
    }
}
