using FitControl.Domain.Common;
using FitControl.Domain.Entities;

namespace FitControl.Domain.Interfaces
{
    public interface IMembershipPlanRepository : IGenericRepository<MembershipPlan>
    {
        Task<MembershipPlan?> GetByNameAsync(string name);
        Task<IEnumerable<MembershipPlan>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<IEnumerable<MembershipPlan>> GetActivePlanAsync();
    }
}
