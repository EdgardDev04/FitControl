using FitControl.Application.Common;
using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces.Services
{
    public interface IMemberService
    {
        Task<MemberDto> CreateMemberAsync(CreateMemberDto dto);
        Task UpdateMemberAsync(int id, UpdateMemberDto dto);
        Task DeleteMemberAsync(int id);
        Task ChangeMemberStatusAsync(int id, bool status);
        Task<PagedResult<MemberDto>> GetPagedMembersAsync(PaginationParams paginationParams);
        Task<MemberDto> GetMemberAsync(int id);
        Task<MemberDto> GetMemberByEmailAsync(string email);
        Task<MemberDto> GetMemberByNameAsync(string name);
        Task<MemberDto> GetMemberByPhoneNumberAsync(string phoneNumber);
        Task<ICollection<MemberDto>> GetAllMembersAsync();
        Task<ICollection<MemberDto>> GetActiveMembersAsync();
        Task<ICollection<MemberDto>> GetInactiveMembersAsync();
    }
}
