using Application.DTOs;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetAllAsync();
    Task<BookDto> GetByIdAsync(int id);
    Task<BookDto> CreateAsync(BookDto book);
    Task<BookDto> UpdateAsync(int id, BookDto book);
    Task<bool> DeleteAsync(int id);
}
