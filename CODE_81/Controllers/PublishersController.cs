using Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task___Code_81__.Models;

[ApiController]
[Route("api/[controller]")]
public class PublishersController : ControllerBase
{
    private readonly IPublisherService _publisherService;

    public PublishersController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPublishers()
    {
        var publishers = await _publisherService.GetAllAsync();
        return Ok(publishers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPublisher(int id)
    {
        var publisher = await _publisherService.GetByIdAsync(id);
        if (publisher == null) return NotFound();
        return Ok(publisher);
    }

    [HttpPost]
    [Authorize(Roles = "Administrator,Librarian")]
    public async Task<IActionResult> CreatePublisher([FromBody] PublisherDto publisher)
    {
        var createdPublisher = await _publisherService.CreateAsync(publisher);
        return CreatedAtAction(nameof(GetPublisher), new { id = createdPublisher.Id }, createdPublisher);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator,Librarian")]
    public async Task<IActionResult> UpdatePublisher(int id, [FromBody] PublisherDto publisher)
    {
        var updatedPublisher = await _publisherService.UpdateAsync(id, publisher);
        if (updatedPublisher == null) return BadRequest();
        return Ok(updatedPublisher);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeletePublisher(int id)
    {
        var deleted = await _publisherService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
