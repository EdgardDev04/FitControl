using FitControl.Application.Common;
using FitControl.Domain.Entities;

namespace FitControl.Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByUserNameAsync(string name);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByUsernameAsync(string username);
        Task<ICollection<User>> GetActiveUsersAsync();
        Task<ICollection<User>> GetInactiveUsersAsync();
        Task<ICollection<User>> GetByRegistrationDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<ICollection<User>> GetByLastLoginDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}

