using FitControl.Application.Common;
using FitControl.Domain.Entities;

namespace FitControl.Application.Interfaces.Repositories
{
    public interface IMembershipPlanRepository : IRepositoryBase<MembershipPlan>
    {
        Task<bool> ExistByNameAsync(string name);
        Task<MembershipPlan> GetByNameAsync(string name);
        Task<ICollection<MembershipPlan>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<ICollection<MembershipPlan>> GetAllInactiveAsync();
        Task<ICollection<MembershipPlan>> GetAllActiveAsync();
    }
}
