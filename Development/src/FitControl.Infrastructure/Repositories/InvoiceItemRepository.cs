using FitControl.Domain.Entities;
using FitControl.Domain.Interfaces;
using FitControl.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FitControl.Infrastructure.Repositories
{
    internal class InvoiceItemRepository : IInvoiceItemRepository
    {
        private readonly FitControlDbContext _context;

        public InvoiceItemRepository() { }
        public InvoiceItemRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(InvoiceItem entity) => await _context.InvoiceItems.AddAsync(entity);

        public async Task DeleteAsync(InvoiceItem entity) => _context.InvoiceItems.Remove(entity);

        public async Task<IEnumerable<InvoiceItem>> GetAllAsync() => await _context.InvoiceItems.ToListAsync();

        public async Task<InvoiceItem?> GetByIdAsync(int id) => await _context.InvoiceItems.FindAsync(id);

        public async Task<IEnumerable<InvoiceItem>> GetByInvoiceIdAsync(int invoiceId) => await _context.InvoiceItems.Where(it => it.InvoiceId == invoiceId).ToListAsync();

        public async Task UpdateAsync(InvoiceItem entity) => _context.InvoiceItems.Update(entity);
    }
}
