using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces
{
    public interface IMembershipService
    {
        Task CreateMembershipAsync(CreateMembershipDto dto);

        Task<MembershipDto?> GetMembershipByIdAsync(int membershipId);

        Task<IEnumerable<MembershipDto>> GetMemberMembershipsAsync(int memberId);

        Task<MembershipDto?> GetActiveMembershipAsync(int memberId);

        Task RenewMembershipAsync(int membershipId);

        Task CancelMembershipAsync(int membershipId);

        Task PendingPaymentMembershipAsync(int membershipId);

        Task SuspendedMembershipAsync(int membershipId);

        Task ActiveMembershipAsync(int membershipId);

        Task InactiveMembershipAsync(int membershipId);

        Task ExpiredMembershipAsync(int membershipId);

        Task<bool> HasActiveMembershipAsync(int memberId);
    }
}
