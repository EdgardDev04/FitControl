using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces.Services
{
    public interface IMembershipPlanService
    {
        Task<MembershipPlanDto> CreateMembershipPlanAsync(CreateMembershipPlanDto dto);
        Task UpdatePlanPriceAsync(int id, decimal newPrice);
        Task UpdateMembershipPlanAsync(int id, UpdateMembershipPlanDto dto);
        Task<MembershipPlanDto> GetMembershipPlanAsync(int id);
        Task<ICollection<MembershipPlanDto>> GetActivePlansAsync();
        Task<ICollection<MembershipPlanDto>> GetInactivePlansAsync();
        Task<ICollection<MembershipPlanDto>> GetAllMembershipPlanAsync();
        Task DeleteMembershipPlanAsync(int id);
        Task<MembershipPlanDto> DuplicatePlanAsync(int sourcePlanId, string newPlanName);
    }
}
