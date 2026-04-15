using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces
{
    public interface IMembershipPlanService
    {
        Task CreateMembershipPlanAsync(CreateMembershipPlanDto dto);

        Task UpdateMembershipPlanAsync(int planId, UpdateMembershipPlanDto dto);

        Task DeleteMembershipPlanAsync(int planId);

        Task<MembershipPlanDto?> GetMembershipPlanByIdAsync(int planId);

        Task<IEnumerable<MembershipPlanDto>> GetAllMembershipPlansAsync();

        Task<IEnumerable<MembershipPlanDto>> ActivateMembershipPlanAsync();

        Task DeactivateMembershipPlanAsync(int planId);
    }
}
