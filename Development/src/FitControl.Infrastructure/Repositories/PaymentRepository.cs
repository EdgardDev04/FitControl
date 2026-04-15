using FitControl.Domain.Entities;
using FitControl.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using FitControl.Infrastructure.Persistence.Context;

namespace FitControl.Infrastructure.Repositories
{
    internal class PaymentRepository : IPaymentRepository
    {
        private readonly FitControlDbContext _context;

        public PaymentRepository() { }

        public PaymentRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Payment entity) => await _context.Payments.AddAsync(entity);

        public async Task DeleteAsync(Payment entity) => _context.Payments.Remove(entity);

        public async Task<IEnumerable<Payment>> GetAllAsync() => await _context.Payments.AsNoTracking().ToListAsync();

        public async Task GetByDateAsync(DateTime date)  => await _context.Payments.AsNoTracking().Where(p => p.PaymentDate == date.Date).ToListAsync();

        public async Task<Payment?> GetByIdAsync(int id) => await _context.Payments.FindAsync(id);

        public async Task<IEnumerable<Payment>> GetByInvoiceIdAsync(int invoiceId) => await _context.Payments.AsNoTracking().Where(p => p.InvoiceId == invoiceId).ToListAsync();

        public async Task<IEnumerable<Payment>> GetByMemberIdAsync(int memberId) => await _context.Payments.AsNoTracking().Where(p => p.Membership.MemberId == memberId).ToListAsync();

        public async Task UpdateAsync(Payment entity) => _context.Payments.Update(entity);
    }
}
