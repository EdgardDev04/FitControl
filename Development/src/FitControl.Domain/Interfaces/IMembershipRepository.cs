using FitControl.Domain.Common;
using FitControl.Domain.Entities;
using FitControl.Domain.Enums;

namespace FitControl.Domain.Interfaces
{
    public interface IMembershipRepository : IGenericRepository<Membership>
    {
        Task GetByRangeDateAsync (DateTime startDate, DateTime endDate);
        Task GetByStatusAsync (MembershipStatus status);
        Task GetByMemberIdAsync (int memberId);
        Task GetByMembershipPlanIdAsync (int membershipPlanId);
    }
}
