using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces
{
    public interface IInvoiceService
    {
        Task CreateInvoiceAsync(CreateInvoiceDto dto);

        Task<InvoiceDto?> GetInvoiceByIdAsync(int invoiceId);

        Task<IEnumerable<InvoiceDto>> GetMemberInvoicesAsync(int memberId);

        Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync();

        Task MarkInvoiceAsPaidAsync(int invoiceId);

        Task CancelInvoiceAsync(int invoiceId);
    }
}
