using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberDto>> GetAllMembersAsync();
        Task<IEnumerable<MemberDto>> GetAllActivateMembersAsync();
        Task<IEnumerable<MemberDto>> GetAllInactiveMembersAsync();
        Task RegisterMemberAsync(MemberDto memberDto);
        Task UpdateMemberAsync(int id, MemberDto memberDto);
        Task MarkMemberAsInactiveAsync(int id);
        Task MarkMemberAsActiveAsync(int id);
        Task<IEnumerable<MemberDto>> SearchMembersAsync(string query);
        Task DeleteMemberAsync(int id);
        Task<MemberDto> GetMemberByIdAsync(int id);
    }
}
