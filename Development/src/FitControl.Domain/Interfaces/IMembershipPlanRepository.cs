using FitControl.Domain.Common;
using FitControl.Domain.Entities;

namespace FitControl.Domain.Interfaces
{
    public interface IMembershipPlanRepository : IGenericRepository<MembershipPlan>
    {
        Task GetByNameAsync (string name);
        Task GetByPriceRangeAsync (decimal minPrice, decimal maxPrice);
        Task GetActivePlanAsync();
    }
}
