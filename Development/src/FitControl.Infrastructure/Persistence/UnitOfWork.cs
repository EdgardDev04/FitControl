using FitControl.Application.Interfaces;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace FitControl.Infrastructure.Persistence
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly FitControlDbContext _context;
        private IDbContextTransaction? _currentTransaction;
        private bool _disposed;

        public IAttendanceRepository Attendances { get; }
        public IMemberRepository Members { get; }
        public IMembershipPlanRepository MembershipPlans { get; }
        public IMembershipRepository Memberships { get; }
        public IPaymentRepository Payments { get; }
        public IPromotionRepository Promotions { get; }
        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }
        public IUserRoleRepository UserRoles { get; }

        public UnitOfWork(
            FitControlDbContext context,
            IAttendanceRepository attendances,
            IMemberRepository members,
            IMembershipPlanRepository membershipPlans,
            IMembershipRepository memberships,
            IPaymentRepository payments,
            IPromotionRepository promotions,
            IUserRepository users,
            IRoleRepository roles,
            IUserRoleRepository userRoles)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Attendances = attendances;
            Members = members;
            MembershipPlans = membershipPlans;
            Memberships = memberships;
            Payments = payments;
            Promotions = promotions;
            Users = users;
            Roles = roles;
            UserRoles = userRoles;
        }

        public bool HasActiveTransaction => _currentTransaction != null;

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction != null)
            {
                return; 
            }

            _currentTransaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction == null)
            {
                throw new InvalidOperationException("Commit cannot be performed because there is no active transaction.");
            }

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                await _currentTransaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await RollbackTransactionAsync(cancellationToken);
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.DisposeAsync();
                    _currentTransaction = null;
                }
            }
        }
        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_currentTransaction == null) return;

            try
            {
                await _currentTransaction.RollbackAsync(cancellationToken);
            }
            finally
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }
        public async ValueTask DisposeAsync()
        {
            if (!_disposed)
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.DisposeAsync();
                    _currentTransaction = null;
                }

                await _context.DisposeAsync();
                _disposed = true;
            }

            GC.SuppressFinalize(this);
        }
    }
}
