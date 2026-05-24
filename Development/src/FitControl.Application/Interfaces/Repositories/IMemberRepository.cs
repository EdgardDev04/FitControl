using FitControl.Application.Common;
using FitControl.Domain.Entities;

namespace FitControl.Application.Interfaces.Repositories
{
    public interface IMemberRepository : IRepositoryBase<Member>
    {
        Task<Member> GetByNameAsync(string name);
        Task<ICollection<Member>> GetActiveMembersAsync();
        Task<ICollection<Member>> GetInactiveMembersAsync();
        Task<ICollection<Member>> GetMembersByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
