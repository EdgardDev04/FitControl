using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces.Services
{
    public interface IPaymentService
    {
        Task ProcessPaymentAsync(int memberId, decimal amount);
        Task<ICollection<PaymentDto>> GetAllPaymentsAsync();
        Task<ICollection<PaymentDto>> GetPaymentsByMemberIdAsync(int memberId);
    }
}
