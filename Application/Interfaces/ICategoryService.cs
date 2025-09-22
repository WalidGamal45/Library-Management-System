using Application.DTOs;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllAsync();
    Task<CategoryDto> GetByIdAsync(int id);
    Task<CategoryDto> CreateAsync(CategoryDto category);
    Task<CategoryDto> UpdateAsync(int id, CategoryDto category);
    Task<bool> DeleteAsync(int id);
}
