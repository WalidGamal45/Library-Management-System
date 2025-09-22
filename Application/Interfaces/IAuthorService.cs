using Application.DTOs;

public interface IAuthorService
{
    Task<IEnumerable<AuthorDto>> GetAllAsync();
    Task<AuthorDto> GetByIdAsync(int id);
    Task<AuthorDto> CreateAsync(AuthorDto author);
    Task<AuthorDto> UpdateAsync(int id, AuthorDto author);
    Task<bool> DeleteAsync(int id);
}
