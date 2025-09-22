using Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAuthors()
    {
        var authors = await _authorService.GetAllAsync();
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthor(int id)
    {
        var author = await _authorService.GetByIdAsync(id);
        if (author == null) return NotFound();
        return Ok(author);
    }

    [HttpPost]
    [Authorize(Roles = "Administrator,Librarian")]
    public async Task<IActionResult> CreateAuthor([FromBody] AuthorDto author)
    {
        var createdAuthor = await _authorService.CreateAsync(author);
        return CreatedAtAction(nameof(GetAuthor), new { id = createdAuthor.Id }, createdAuthor);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator,Librarian")]
    public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorDto author)
    {
        var updatedAuthor = await _authorService.UpdateAsync(id, author);
        if (updatedAuthor == null) return BadRequest();
        return Ok(updatedAuthor);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        var deleted = await _authorService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
