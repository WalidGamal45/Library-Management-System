using Application.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using Task___Code_81__.Models;

public class AuthorService : IAuthorService
{
    private readonly LibraryDbContext _context;

    public AuthorService(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AuthorDto>> GetAllAsync()
    {
        return await _context.Authors
            .Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name
            })
            .ToListAsync();
    }

    public async Task<AuthorDto> GetByIdAsync(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author == null) return null;

        return new AuthorDto
        {
            Id = author.Id,
            Name = author.Name
        };
    }

    public async Task<AuthorDto> CreateAsync(AuthorDto authorDto)
    {
        var author = new Author
        {
            Name = authorDto.Name
        };

        _context.Authors.Add(author);
        await _context.SaveChangesAsync();

        authorDto.Id = author.Id;
        return authorDto;
    }

    public async Task<AuthorDto> UpdateAsync(int id, AuthorDto authorDto)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author == null) return null;

        author.Name = authorDto.Name;
        await _context.SaveChangesAsync();

        authorDto.Id = author.Id;
        return authorDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author == null) return false;

        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
        return true;
    }
}
