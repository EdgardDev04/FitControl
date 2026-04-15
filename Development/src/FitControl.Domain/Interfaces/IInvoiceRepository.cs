using FitControl.Domain.Common;
using FitControl.Domain.Entities;

namespace FitControl.Domain.Interfaces
{
    public interface IInvoiceRepository : IGenericRepository<Invoice>
    {
        Task GetByInvoiceNumberAsynnc(string invoiceNumber);
        Task GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<List<Invoice>> GetByMemberIdAsync(int memberId);

    }
}
