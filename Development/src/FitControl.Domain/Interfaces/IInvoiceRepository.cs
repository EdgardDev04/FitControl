using FitControl.Domain.Common;
using FitControl.Domain.Entities;

namespace FitControl.Domain.Interfaces
{
    public interface IInvoiceRepository : IGenericRepository<Invoice>
    {
        Task GetByInvoiceNumberAsynnc(string invoiceNumber);
        Task GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task GetByMemberIdAsync(int memberId);

    }
}
