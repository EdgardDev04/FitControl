namespace FitControl.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IClassBookingRepository ClassBookings { get; }
        IClassSessionRepository ClassSessions { get; }
        IClassTypeRepository ClassTypes { get; }
        IMemberRepository Members { get; }
        IMembershipRepository Memberships { get; }
        IMembershipPlanRepository MembershipPlans { get; }
        IPaymentRepository Payments { get; }

        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
    }
}
