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

        public async Task<IEnumerable<Payment>> GetAllAsync() => await _context.Payments.ToListAsync();

        public async Task GetByDateAsync(DateTime date)  => await _context.Payments.Where(p => p.PaymentDate == date.Date).ToListAsync();

        public async Task<Payment?> GetByIdAsync(int id) => await _context.Payments.FindAsync(id);

        public async Task GetByInvoiceIdAsync(int invoiceId) => await _context.Payments.Where(p => p.InvoiceId == invoiceId).ToListAsync();

        public async Task UpdateAsync(Payment entity) => _context.Payments.Update(entity);
    }
}
