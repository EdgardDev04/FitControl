using FitControl.Application.Common;
using FitControl.Domain.Entities;
using FitControl.Domain.Enums;

namespace FitControl.Application.Interfaces.Repositories
{
    public interface IMembershipRepository : IRepositoryBase<Membership>
    {
        Task<ICollection<Membership>> GetMembershipsByMembershipPlanIdAsync(int membershipPlanId);
        Task<ICollection<Membership>> GetMembershipsByMemberIdAsync(int memberId);
        Task<ICollection<Membership>> GetMembershipsByStatusAsync(MembershipStatus status);
        Task<ICollection<Membership>> GetMembershipByDateAsync(DateTime startdate, DateTime enddate);

    }
}
