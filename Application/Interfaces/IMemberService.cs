using Application.DTOs;

public interface IMemberService
{
    Task<IEnumerable<MemberDto>> GetAllAsync();
    Task<MemberDto> GetByIdAsync(int id);
    Task<MemberDto> CreateAsync(MemberDto member);
    Task<MemberDto> UpdateAsync(int id, MemberDto member);
    Task<bool> DeleteAsync(int id);
}
