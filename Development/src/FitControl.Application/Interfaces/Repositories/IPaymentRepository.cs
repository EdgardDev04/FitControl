using FitControl.Application.Common;
using FitControl.Domain.Entities;
using FitControl.Domain.Enums;

namespace FitControl.Application.Interfaces.Repositories
{
    public interface IPaymentRepository : IRepositoryBase<Payment>
    {
        Task<Payment> GetByAmountAsync(decimal amount);
        Task<Payment> GetByDateAsync(DateTime date);
        Task<ICollection<Payment>> GetByPaymentDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<ICollection<Payment>> GetByMethodAsync(PaymentMethod method);
        Task<ICollection<Payment>> GetByStatusAsync(PaymentStatus status);
        Task<ICollection<Payment>> GetByRangeAmountAsync(decimal minAmount, decimal maxAmount);
        Task<ICollection<Payment>> GetPaymentsByUserIdAsync(int userId);
    }
}
