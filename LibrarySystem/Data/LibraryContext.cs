using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Data;
public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Borrower> Borrowers => Set<Borrower>();
    public DbSet<Loan> Loans => Set<Loan>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .HasMany(a => a.Books).WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId);

        // Loan is the explicit join entity for Book <-> Borrower.
        // LoanDate is included in the key to allow repeated loans of the same book.
        modelBuilder.Entity<Loan>()
            .HasKey(l => new { l.BookId, l.BorrowerId, l.LoanDate });

        modelBuilder.Entity<Book>()
            .HasMany(b => b.Loans).WithOne(l => l.Book)
            .HasForeignKey(l => l.BookId);

        modelBuilder.Entity<Borrower>()
            .HasMany(b => b.Loans).WithOne(l => l.Borrower)
            .HasForeignKey(l => l.BorrowerId);

        modelBuilder.Entity<Book>().Property(b => b.ISBN).HasMaxLength(20);
    }
}
