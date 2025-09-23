using Application.DTOs;
using Microsoft.EntityFrameworkCore;

public class MemberService : IMemberService
{
    private readonly LibraryDbContext _context;

    public MemberService(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MemberDto>> GetAllAsync()
    {
        return await _context.Members
            .Select(m => new MemberDto
            {
                Id = m.Id,
                FullName = m.FullName,
                Email = m.Email,
                Phone = m.Phone,
                JoinedAt = m.JoinedAt
            })
            .ToListAsync();
    }

    public async Task<MemberDto> GetByIdAsync(int id)
    {
        var member = await _context.Members.FindAsync(id);
        if (member == null) return null;

        return new MemberDto
        {
            Id = member.Id,
            FullName = member.FullName,
            Email = member.Email,
            Phone = member.Phone,
            JoinedAt = member.JoinedAt
        };
    }

    public async Task<MemberDto> CreateAsync(MemberDto memberDto)
    {
        try
        {
            var member = new Member
            {
                FullName = memberDto.FullName,
                Email = memberDto.Email,
                Phone = memberDto.Phone,
                JoinedAt = memberDto.JoinedAt
            };

            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            memberDto.Id = member.Id;
            return memberDto;
        }
        catch (Exception ex)
        {
            throw ex;
        }
       
    }

    public async Task<MemberDto> UpdateAsync(int id, MemberDto memberDto)
    {
        var member = await _context.Members.FindAsync(id);
        if (member == null) return null;

        member.FullName = memberDto.FullName;
        member.Email = memberDto.Email;
        member.Phone = memberDto.Phone;
        member.JoinedAt = memberDto.JoinedAt;

        await _context.SaveChangesAsync();

        memberDto.Id = member.Id;
        return memberDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var member = await _context.Members.FindAsync(id);
        if (member == null) return false;

        _context.Members.Remove(member);
        await _context.SaveChangesAsync();
        return true;
    }
}
