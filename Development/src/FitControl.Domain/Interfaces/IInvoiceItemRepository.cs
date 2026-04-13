using FitControl.Domain.Common;
using FitControl.Domain.Entities;

namespace FitControl.Domain.Interfaces
{
    public interface IInvoiceItemRepository : IGenericRepository<InvoiceItem>
    {
        Task <IEnumerable<InvoiceItem>> GetByInvoiceIdAsync(int invoiceId);
         
    }
}
