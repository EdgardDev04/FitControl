using FitControl.Domain.Common;
using FitControl.Domain.Entities;
using FitControl.Domain.Enums;

namespace FitControl.Domain.Interfaces
{
    public interface IMembershipRepository : IGenericRepository<Membership>
    {
        Task<List<Membership>> GetByRangeDateAsync (DateTime startDate, DateTime endDate);
        Task<List<Membership>> GetByStatusAsync (MembershipStatus status);
        Task<List<Membership>> GetAllByMemberIdAsync(int memberId);
        Task<Membership?> GetByMemberIdAsync (int memberId);
        Task<List<Membership>> GetByMembershipPlanIdAsync (int membershipPlanId);
    }
}
