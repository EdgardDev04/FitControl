using FitControl.Application.Interfaces.Repositories;

namespace FitControl.Application.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IAttendanceRepository Attendances { get; }
        IMemberRepository Members { get; }
        IMembershipPlanRepository MembershipPlans { get; }
        IMembershipRepository Memberships { get; }
        IPaymentRepository Payments { get; }
        IPromotionRepository Promotions { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        public IUserRoleRepository UserRoles { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
        bool HasActiveTransaction { get; }
    }
}
