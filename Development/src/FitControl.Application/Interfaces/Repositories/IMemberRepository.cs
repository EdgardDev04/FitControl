using FitControl.Application.Common;
using FitControl.Domain.Entities;

namespace FitControl.Application.Interfaces.Repositories
{
    public interface IMemberRepository : IRepositoryBase<Member>
    {
        Task<bool> ExistDocumentNumber (string documentNumber);
        Task<bool> ExistEmail (string email);
        Task<Member> GetByNameAsync(string name);
        Task<Member> GetByEmailAsync(string email);
        Task<Member> GetByPhoneNumberAsync(string phoneNumber);
        Task<ICollection<Member>> GetAllActiveAsync();
        Task<ICollection<Member>> GetAllInactiveAsync();
        Task<ICollection<Member>> GetAllByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
