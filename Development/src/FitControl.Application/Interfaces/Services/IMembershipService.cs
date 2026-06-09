using FitControl.Application.DTOs;
using FitControl.Domain.Enums;

namespace FitControl.Application.Interfaces.Services
{
    public interface IMembershipService
    {
        Task<MembershipDto> CreateMembershipAsync(CreateMembershipDto dto);
        Task DeleteMembershipAsync(int id);
        Task UpdateMembershipAsync(int id, UpdateMembershipDto dto);
        Task<MembershipDto> GetMembershipAsync(int id);
        Task<ICollection<MembershipDto>> GetMembershipByStatusAsync(MembershipStatus status);
        Task<ICollection<MembershipDto>> GetMembershipsByMembershipPlanIdAsync(int membershipPlanId);
        Task<ICollection<MembershipDto>> GetAllMembershipAsync();
        Task<MembershipDto> GetActiveMembershipByMemberIdAsync(int memberId);
        Task CancelMembershipAsync(int id, CancelMembershipDto dto); 
        Task<MembershipDto> RenewMembershipAsync(int id, RenewMembershipDto dto);

    }
}
