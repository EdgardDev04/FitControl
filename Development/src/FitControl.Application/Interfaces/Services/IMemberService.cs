using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces.Services
{
    public interface IMemberService
    {
        Task CreateMemberAsync(CreateMemberDto dto);
        Task UpdateMemberAsync(int id, UpdateMemberDto dto);
        Task DeleteMemberAsync(int id);
        Task<MemberDto> GetMemberByIdAsync(int id);
        Task<MemberDto> GetMemberByEmailAsync(string email);
        Task<MemberDto> GetMemberByNameAsync(string name);
        Task<ICollection<MemberDto>> GetAllMembersAsync();
        Task<ICollection<MemberDto>> GetActiveMembersAsync();
        Task<ICollection<MemberDto>> GetInactiveMembersAsync();
    }
}
