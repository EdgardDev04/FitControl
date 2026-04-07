using FitControl.Domain.Common;
using FitControl.Domain.Entities;

namespace FitControl.Domain.Interfaces
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task GetByDateAsync (DateTime date);     
        Task GetByInvoiceIdAsync (int invoiceId);
    }
}
