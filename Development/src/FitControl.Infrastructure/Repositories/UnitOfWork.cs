using FitControl.Domain.Interfaces;
using FitControl.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace FitControl.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FitControlDbContext _context;
        private IDbContextTransaction? _currentTransaction;
        private bool _disposed;

        public UnitOfWork(FitControlDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        private IAttendanceRepository _attendances;
        private IClassBookingRepository _classBookings;
        private IClassSessionRepository _classSessions;
        private IClassTypeRepository _classTypes;
        private IGymRepository _gyms;
        private IInvoiceItemRepository _invoiceItems;
        private IInvoiceRepository _invoices;
        private IMemberRepository _members;
        private IMembershipRepository _memberships;
        private IMembershipPlanRepository _membershipPlans;
        private IPaymentRepository _payments;
        private ITrainerRepository _trainers;


        public IAttendanceRepository Attendances => _attendances ??= new AttendanceRepository(_context);
        public IClassBookingRepository ClassBookings => _classBookings ??= new ClassBookingRepository(_context);
        public IClassSessionRepository ClassSessions => _classSessions ??= new ClassSessionRepository(_context);
        public IClassTypeRepository ClassTypes => _classTypes ??= new ClassTypeRepository(_context);
        public IGymRepository Gyms => _gyms ??= new GymRepository(_context);
        public IInvoiceItemRepository InvoiceItems => _invoiceItems ??= new InvoiceItemRepository(_context);
        public IInvoiceRepository Invoices => _invoices ??= new InvoiceRepository(_context);
        public IMemberRepository Members => _members ??= new MemberRepository(_context);
        public IMembershipRepository Memberships => _memberships ??= new MembershipRepository(_context);
        public IMembershipPlanRepository MembershipPlans => _membershipPlans ??= new MembershipPlanRepository(_context);
        public IPaymentRepository Payments => _payments ??= new PaymentRepository(_context);
        public ITrainerRepository Trainers => _trainers ??= new TrainerRepository(_context);
        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction != null)
                return;

            _currentTransaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction == null)
                throw new InvalidOperationException("No active transaction.");

            await _currentTransaction.CommitAsync(cancellationToken);
            await _currentTransaction.DisposeAsync();

            _currentTransaction = null;
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction == null)
                return;

            await _currentTransaction.RollbackAsync(cancellationToken);
            await _currentTransaction.DisposeAsync();

            _currentTransaction = null;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _context.Dispose();
                _disposed = true;
            }

            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            if (!_disposed)
            {
                await _context.DisposeAsync();
                _disposed = true;
            }

            GC.SuppressFinalize(this);
        }
    }
}
