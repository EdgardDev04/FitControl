using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces
{
    public interface IPaymentService
    {
        Task RegisterPaymentAsync(CreatePaymentDto dto);
        Task<PaymentDto?> GetPaymentByIdAsync(int paymentId);
        Task<IEnumerable<PaymentDto>> GetInvoicePaymentsAsync(int invoiceId);
        Task<IEnumerable<PaymentDto>> GetMemberPaymentsAsync(int memberId); 
        Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync();
    }
}
