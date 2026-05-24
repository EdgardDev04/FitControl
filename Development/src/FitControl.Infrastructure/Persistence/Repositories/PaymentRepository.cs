using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Infrastructure.Persistence.Context;
using FitControl.Domain.Enums;

namespace FitControl.Infrastructure.Persistence.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly FitControlDbContext _context;

        public PaymentRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Payment payment) => await _context.Payments.AddAsync(payment);
        public async Task DeleteAsync(Payment payment) => _context.Payments.Remove(payment);
        public async Task<IEnumerable<Payment>> GetAllAsync() => await _context.Payments.ToListAsync();

        public Task<Payment> GetByAmountAsync(decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetByDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<Payment?> GetByIdAsync(int id) => await _context.Payments.FindAsync(id);
        public async Task<ICollection<Payment>> GetByMethodAsync(PaymentMethod method) => await _context.Payments.Where(p => p.Method == method).ToListAsync();
        public async Task<ICollection<Payment>> GetByPaymentDateRangeAsync(DateTime startDate, DateTime endDate) => await _context.Payments.Where(p => p.PaidAt >= startDate && p.PaidAt <= endDate).ToListAsync();
        public async Task<ICollection<Payment>> GetByRangeAmountAsync(decimal minAmount, decimal maxAmount) => await _context.Payments.Where(p => p.Amount >= minAmount && p.Amount <= maxAmount).ToListAsync();
        public async Task<ICollection<Payment>> GetByStatusAsync(PaymentStatus status) => await _context.Payments.Where(p => p.Status == status).ToListAsync();
        public async Task<ICollection<Payment>> GetPaymentsByUserIdAsync(int userId) => await _context.Payments.Where(p => p.MemberId == userId).ToListAsync();
        public async Task UpdateAsync(Payment entity) => _context.Payments.Update(entity);
    }
}
