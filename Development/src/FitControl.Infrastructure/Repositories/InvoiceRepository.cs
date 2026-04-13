using FitControl.Domain.Entities;
using FitControl.Domain.Interfaces;
using FitControl.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FitControl.Infrastructure.Repositories
{
    internal class InvoiceRepository : IInvoiceRepository
    {
        private readonly FitControlDbContext _context;

        public InvoiceRepository() { }
        public InvoiceRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Invoice entity) => await _context.Invoices.AddAsync(entity);

        public async Task DeleteAsync(Invoice entity) => _context.Invoices.Remove(entity);

        public async Task<IEnumerable<Invoice>> GetAllAsync() => await _context.Invoices.ToListAsync();

        public async Task GetByDateRangeAsync(DateTime startDate, DateTime endDate) => await _context.Invoices.AsNoTracking().Where( i => i.IssueDate >= startDate && i.IssueDate <= endDate).ToListAsync();

        public async Task<Invoice?> GetByIdAsync(int id) => await _context.Invoices.FindAsync(id);

        public async Task GetByInvoiceNumberAsynnc(string invoiceNumber) => await _context.Invoices.FirstOrDefaultAsync(i => i.InvoiceNumber == invoiceNumber);

        public async Task GetByMemberIdAsync(int memberId) => await _context.Invoices.Where(i => i.MemberId == memberId).ToListAsync();

        public async Task UpdateAsync(Invoice entity) =>  _context.Invoices.Update(entity);
    }
}
