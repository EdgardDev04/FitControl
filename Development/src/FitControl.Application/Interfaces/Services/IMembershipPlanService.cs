using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces.Services
{
    public interface IMembershipPlanService
    {
        Task CreateMembershipPlanAsync(CreateMembershipPlanDto dto);
        Task UpdatePlanPriceAsync(int id, decimal newPrice);
        Task UpdateMembershipPlanAsync(int id, UpdateMembershipPlanDto dto);
        Task<ICollection<MembershipPlanDto>> GetActivePlansAsync();
        Task<ICollection<MembershipPlanDto>> GetInactivePlansAsync();
        Task<MembershipPlanDto> GetMembershipPlanByIdAsync(int id);
        Task<ICollection<MembershipPlanDto>> GetAllMembershipPlanAsync();
        Task DeleteMembershipPlanAsync(int id);
    }
}
