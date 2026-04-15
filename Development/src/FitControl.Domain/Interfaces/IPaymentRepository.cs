using FitControl.Domain.Common;
using FitControl.Domain.Entities;

namespace FitControl.Domain.Interfaces
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task GetByDateAsync (DateTime date);     
        Task<IEnumerable<Payment>> GetByInvoiceIdAsync (int invoiceId);
        Task<IEnumerable<Payment>> GetByMemberIdAsync (int memberId);
    }
}
