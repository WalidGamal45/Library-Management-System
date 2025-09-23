using Application.DTOs;

public interface IBorrowTransactionService
{
    Task<IEnumerable<BorrowTransactionDto>> GetAllAsync();
    Task<BorrowTransactionDto> GetByIdAsync(int id);
    Task<BorrowTransactionDto> BorrowBookAsync(BorrowBookDto request, string userId);
    Task<BorrowTransactionDto> ReturnBookAsync(int transactionId, string userId);
}
