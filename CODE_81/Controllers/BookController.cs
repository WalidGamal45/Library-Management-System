using Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }
    [HttpGet("search")]
    public async Task<IActionResult> SearchBooks(
      [FromQuery] string? title,
      [FromQuery] string? author,
      [FromQuery] string? category)
    {
        var books = await _bookService.SearchBooks(title, author, category);
        return Ok(books);
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _bookService.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var book = await _bookService.GetByIdAsync(id);
        if (book == null) return NotFound();
        return Ok(book);
    }

    [HttpPost]
    [Authorize]
 //   [Authorize(Roles = "Administrator,Librarian")]
    public async Task<IActionResult> CreateBook([FromBody] BookDto book)
    {
        var createdBook = await _bookService.CreateAsync(book);
        return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
    }

    [HttpPut("{id}")]
    [Authorize]
    // [Authorize(Roles = "Administrator,Librarian")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDto book)
    {
        var updatedBook = await _bookService.UpdateAsync(id, book);
        if (updatedBook == null) return BadRequest();
        return Ok(updatedBook);
    }

    [HttpDelete("{id}")]
    [Authorize]
    //[Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var deleted = await _bookService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
