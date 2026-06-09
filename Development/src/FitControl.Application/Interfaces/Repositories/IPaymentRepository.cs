using FitControl.Application.Common;
using FitControl.Domain.Entities;
using FitControl.Domain.Enums;

namespace FitControl.Application.Interfaces.Repositories
{
    public interface IPaymentRepository : IRepositoryBase<Payment>
    {
        Task<bool> AnyPendingByMemberIdAsync(int memberId);
        Task<Payment> GetbyMemberIdAsync (int memberId);
        Task<Payment> GetByAmountAsync(decimal amount);
        Task<Payment> GetByDateAsync(DateTime date);
        Task<ICollection<Payment>> GetAllByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<ICollection<Payment>> GetAllByMethodAsync(PaymentMethod method);
        Task<ICollection<Payment>> GetAllByStatusAsync(PaymentStatus status);
        Task<ICollection<Payment>> GetAllByRangeAmountAsync(decimal minAmount, decimal maxAmount);
        Task<ICollection<Payment>> GetAllByUserIdAsync(int memberId);
    }
}
