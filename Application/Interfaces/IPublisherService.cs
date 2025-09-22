using Application.DTOs;

public interface IPublisherService
{
    Task<IEnumerable<PublisherDto>> GetAllAsync();
    Task<PublisherDto> GetByIdAsync(int id);
    Task<PublisherDto> CreateAsync(PublisherDto publisher);
    Task<PublisherDto> UpdateAsync(int id, PublisherDto publisher);
    Task<bool> DeleteAsync(int id);
}
