using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class BorrowTransactionsController : ControllerBase
{
    private readonly IBorrowTransactionService _borrowService;

    public BorrowTransactionsController(IBorrowTransactionService borrowService)
    {
        _borrowService = borrowService;
    }

    [HttpGet]
    [Authorize(Roles = "Administrator,Librarian")]
    public async Task<IActionResult> GetTransactions()
    {
        var transactions = await _borrowService.GetAllAsync();
        return Ok(transactions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTransaction(int id)
    {
        var transaction = await _borrowService.GetByIdAsync(id);
        if (transaction == null) return NotFound();
        return Ok(transaction);
    }

    [HttpPost("borrow")]
    [Authorize]
   // [Authorize(Roles = "Administrator,Librarian,Staff")]
    public async Task<IActionResult> BorrowBook(int bookId, int memberId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var transaction = await _borrowService.BorrowBookAsync(bookId, memberId, userId);

        if (transaction == null) return BadRequest("Book not available.");
        return Ok(transaction);
    }

    [HttpPost("return/{id}")]
    [Authorize]
    // [Authorize(Roles = "Administrator,Librarian,Staff")]
    public async Task<IActionResult> ReturnBook(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var transaction = await _borrowService.ReturnBookAsync(id, userId);

        if (transaction == null) return BadRequest("Invalid return operation.");
        return Ok(transaction);
    }
}
