using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Infrastructure.Persistence.Context;
using FitControl.Domain.Enums;

namespace FitControl.Infrastructure.Persistence.Repositories
{
    internal class PaymentRepository : IPaymentRepository
    {
        private readonly FitControlDbContext _context;

        public PaymentRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Payment payment) => await _context.Payments.AddAsync(payment);
        public async Task DeleteAsync(Payment payment) => _context.Payments.Remove(payment);
        public async Task<IEnumerable<Payment>> GetAllAsync() => await _context.Payments.ToListAsync();
        public async Task<ICollection<Payment>> GetAllByDateRangeAsync(DateTime startDate, DateTime endDate) => await _context.Payments.Where(p => p.PaidAt >= startDate && p.PaidAt <= endDate).ToListAsync();
        public async Task<ICollection<Payment>> GetAllByMethodAsync(PaymentMethod method) => await _context.Payments.Where(p => p.Method == method).ToListAsync();
        public async Task<ICollection<Payment>> GetAllByRangeAmountAsync(decimal minAmount, decimal maxAmount) => await _context.Payments.Where(p => p.Amount >= minAmount && p.Amount <= maxAmount).ToListAsync();
        public async Task<ICollection<Payment>> GetAllByStatusAsync(PaymentStatus status) => await _context.Payments.Where(p => p.Status == status).ToListAsync();
        public async Task<ICollection<Payment>> GetAllByUserIdAsync(int memberId) => await _context.Payments.Where(p => p.MemberId == memberId).ToListAsync();
        public async Task<Payment?> GetByAmountAsync(decimal amount) => await _context.Payments.FirstOrDefaultAsync(p => p.Amount == amount);
        public async Task<Payment?> GetByDateAsync(DateTime date) => await _context.Payments.FirstOrDefaultAsync(p => p.PaidAt == date);
        public async Task<Payment?> GetByIdAsync(int id) => await _context.Payments.FindAsync(id);
        public async Task<Payment?> GetbyMemberIdAsync(int memberId) => await _context.Payments.FirstOrDefaultAsync(p => p.MemberId == memberId);
        public async Task UpdateAsync(Payment payment) => _context.Payments.Update(payment);
    }
}
 