using Application.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using Task___Code_81__.Models;

public class BookService : IBookService
{
    
    private readonly LibraryDbContext _context;

    public BookService(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BookDto>> GetAllAsync()
    {
        return await _context.Books
            .Include(b => b.Publisher)
            .Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                PublisherName = b.Publisher.Name,
                Status = b.Status,
                CopiesAvailable = b.CopiesAvailable,
               

            })
            .ToListAsync();
    }

    public async Task<BookDto> GetByIdAsync(int id)
    {
        var book = await _context.Books
            .Include(b => b.Publisher)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book == null) return null;

        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            ISBN = book.ISBN,
            PublisherName = book.Publisher.Name,
            Status = book.Status,
            CopiesAvailable = book.CopiesAvailable
        };
    }

    public async Task<BookDto> CreateAsync(BookDto bookDto)
    {
        try
        {
            var book = new Book
            {
                Title = bookDto.Title,
                ISBN = bookDto.ISBN,
                Status = bookDto.Status,
                CopiesAvailable = bookDto.CopiesAvailable,
                Description= bookDto.Description,
                PublisherId = bookDto.PublisherId

            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            bookDto.Id = book.Id;
            return bookDto;

        }
        catch(Exception ex)
        {
            throw ex;
        }


       
    }

    public async Task<BookDto> UpdateAsync(int id, BookDto bookDto)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return null;

        book.Title = bookDto.Title;
        book.ISBN = bookDto.ISBN;
        book.Status = bookDto.Status;
        book.CopiesAvailable = bookDto.CopiesAvailable;
        book.Description = bookDto.Description;
        book.PublisherId = bookDto.PublisherId;

        await _context.SaveChangesAsync();
        bookDto.Id = book.Id;
        return bookDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return false;

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<IEnumerable<Book>> SearchBooks(string? title, string? author, string? category)
    {
        var query = _context.Books
            .Include(b => b.Publisher)
            .Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
            .Include(b => b.BookCategories).ThenInclude(bc => bc.Category)
            .AsQueryable();

        if (!string.IsNullOrEmpty(title))
            query = query.Where(b => b.Title.Contains(title));

        if (!string.IsNullOrEmpty(author))
            query = query.Where(b => b.BookAuthors.Any(ba => ba.Author.Name.Contains(author)));

        if (!string.IsNullOrEmpty(category))
            query = query.Where(b => b.BookCategories.Any(bc => bc.Category.Name.Contains(category)));

        return await query.ToListAsync();
    }


}
