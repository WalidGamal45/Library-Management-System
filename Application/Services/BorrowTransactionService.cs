using Application.DTOs;
using Microsoft.EntityFrameworkCore;

public class BorrowTransactionService : IBorrowTransactionService
{
    private readonly LibraryDbContext _context;

    public BorrowTransactionService(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BorrowTransactionDto>> GetAllAsync()
    {
        return await _context.BorrowTransactions
            .Include(bt => bt.Book)
            .Include(bt => bt.Member)
            .Select(bt => new BorrowTransactionDto
            {
                Id = bt.Id,
                BookId = bt.BookId,
                BookTitle = bt.Book.Title,
                MemberId = bt.MemberId,
                MemberName = bt.Member.FullName,
                BorrowDate = bt.BorrowDate,
                DueDate = bt.DueDate,
                ReturnDate = bt.ReturnDate
            })
            .ToListAsync();
    }

    public async Task<BorrowTransactionDto> GetByIdAsync(int id)
    {
        var transaction = await _context.BorrowTransactions
            .Include(bt => bt.Book)
            .Include(bt => bt.Member)
            .FirstOrDefaultAsync(bt => bt.Id == id);

        if (transaction == null) return null;

        return new BorrowTransactionDto
        {
            Id = transaction.Id,
            BookId = transaction.BookId,
            BookTitle = transaction.Book.Title,
            MemberId = transaction.MemberId,
            MemberName = transaction.Member.FullName,
            BorrowDate = transaction.BorrowDate,
            DueDate = transaction.DueDate,
            ReturnDate = transaction.ReturnDate
        };
    }

    public async Task<BorrowTransactionDto> BorrowBookAsync(BorrowBookDto request, string userId)
    {
        var book = await _context.Books.FindAsync(request.bookId);
        if (book == null || book.CopiesAvailable <= 0) return null;

        var member = await _context.Members.FindAsync(request.memberId);
        if (member == null) return null;

        book.CopiesAvailable -= 1;

        var transaction = new BorrowTransaction
        {
            BookId = request.bookId,
            MemberId = request.memberId,
            BorrowDate = DateTime.UtcNow,
            DueDate = DateTime.UtcNow.AddDays(14), // مثال: الاستعارة لمدة أسبوعين
            CreatedByUserId = userId,
            ProcessedByUserId=userId
        };

        _context.BorrowTransactions.Add(transaction);
        await _context.SaveChangesAsync();

        return new BorrowTransactionDto
        {
            Id = transaction.Id,
            BookId = request.bookId,
            BookTitle = book.Title,
            MemberId = request.memberId,
            MemberName = member.FullName,
            BorrowDate = transaction.BorrowDate,
            DueDate = transaction.DueDate,
            ReturnDate = transaction.ReturnDate
        };
    }

    public async Task<BorrowTransactionDto> ReturnBookAsync(int transactionId, string userId)
    {
        try
        {


            var transaction = await _context.BorrowTransactions.Include
                (x=>x.Book).Include(x=>x.Member)
            
            .FirstOrDefaultAsync(bt => bt.Id == transactionId);

            if (transaction == null || transaction.ReturnDate != null) return null;

            transaction.ReturnDate = DateTime.UtcNow;
            transaction.ProcessedByUserId = userId;

            transaction.Book.CopiesAvailable += 1;

            await _context.SaveChangesAsync();

            return new BorrowTransactionDto
            {
            Id = transaction.Id,
            BookId = transaction.BookId,
            BookTitle = transaction.Book.Title,
            MemberId = transaction.MemberId,
            MemberName = transaction.Member.FullName,
            BorrowDate = transaction.BorrowDate,
            DueDate = transaction.DueDate,
            ReturnDate = transaction.ReturnDate
            }
            ;
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}
