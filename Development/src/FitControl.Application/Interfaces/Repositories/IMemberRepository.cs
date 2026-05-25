using FitControl.Application.Common;
using FitControl.Domain.Entities;

namespace FitControl.Application.Interfaces.Repositories
{
    public interface IMemberRepository : IRepositoryBase<Member>
    {
        Task<Member> GetByNameAsync(string name);
        Task<Member> GetByEmailAsync(string email);
        Task<ICollection<Member>> GetAllActiveAsync();
        Task<ICollection<Member>> GetAllInactiveAsync();
        Task<ICollection<Member>> GetAllByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
