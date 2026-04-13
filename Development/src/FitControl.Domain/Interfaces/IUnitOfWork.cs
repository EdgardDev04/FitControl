namespace FitControl.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        IAttendanceRepository Attendances { get; }
        IClassBookingRepository ClassBookings { get; }
        IClassSessionRepository ClassSessions { get; }
        IClassTypeRepository ClassTypes { get; }
        IGymRepository Gyms { get; }
        IInvoiceItemRepository InvoiceItems { get; }
        IInvoiceRepository Invoices { get; }
        IMemberRepository Members { get; }
        IMembershipRepository Memberships { get; }
        IMembershipPlanRepository MembershipPlans { get; }
        IPaymentRepository Payments { get; }
        ITrainerRepository Trainers { get; }

        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
    }
}
