using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> ProcessPaymentAsync(ProcessPaymentDto dto); 
        Task<RefundResponseDto> RefundPaymentAsync(int paymentId, RefundRequestDto dto);
        Task<ICollection<PaymentDto>> GetAllPaymentsAsync();
        Task<ICollection<PaymentDto>> GetPaymentsByMemberIdAsync(int memberId);
        Task<PaymentDto> GetPaymentAsync(int id);

    }
}
