// Data/LibraryDbContext.cs
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task___Code_81__.Models;

public class LibraryDbContext : IdentityDbContext<ApplicationUser>
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<BookCategory> BookCategories { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<BorrowTransaction> BorrowTransactions { get; set; }
    public DbSet<ActivityLog> ActivityLogs { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<BookAuthor>().HasKey(b => new { b.BookId, b.AuthorId });
        builder.Entity<BookCategory>().HasKey(b => new { b.BookId, b.CategoryId });
        
    }
}
