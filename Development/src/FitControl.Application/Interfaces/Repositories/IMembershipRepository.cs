using FitControl.Application.Common;
using FitControl.Domain.Entities;
using FitControl.Domain.Enums;

namespace FitControl.Application.Interfaces.Repositories
{
    public interface IMembershipRepository : IRepositoryBase<Membership>
    {
        Task<ICollection<Membership>> GetByMembershipPlanIdAsync(int membershipPlanId);
        Task<ICollection<Membership>> GetByMemberIdAsync(int memberId);
        Task<ICollection<Membership>> GetAllByStatusAsync(MembershipStatus status);
        Task<ICollection<Membership>> GetAllByDateAsync(DateTime startdate, DateTime enddate);

    }
}
