using Application.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using Task___Code_81__.Models;

public class PublisherService : IPublisherService
{
    private readonly LibraryDbContext _context;

    public PublisherService(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PublisherDto>> GetAllAsync()
    {
        return await _context.Publishers
            .Select(p => new PublisherDto
            {
                Id = p.Id,
                Name = p.Name
            })
            .ToListAsync();
    }

    public async Task<PublisherDto> GetByIdAsync(int id)
    {
        var publisher = await _context.Publishers.FindAsync(id);
        if (publisher == null) return null;

        return new PublisherDto
        {
            Id = publisher.Id,
            Name = publisher.Name
        };
    }

    public async Task<PublisherDto> CreateAsync(PublisherDto publisherDto)
    {
        var publisher = new Publisher
        {
            Name = publisherDto.Name
        };

        _context.Publishers.Add(publisher);
        await _context.SaveChangesAsync();

        publisherDto.Id = publisher.Id;
        return publisherDto;
    }

    public async Task<PublisherDto> UpdateAsync(int id, PublisherDto publisherDto)
    {
        var publisher = await _context.Publishers.FindAsync(id);
        if (publisher == null) return null;

        publisher.Name = publisherDto.Name;
        await _context.SaveChangesAsync();

        publisherDto.Id = publisher.Id;
        return publisherDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var publisher = await _context.Publishers.FindAsync(id);
        if (publisher == null) return false;

        _context.Publishers.Remove(publisher);
        await _context.SaveChangesAsync();
        return true;
    }
}
