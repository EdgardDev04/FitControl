using FitControl.Application.Common;
using FitControl.Domain.Entities;

namespace FitControl.Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByUsernameAsync(string username);
        Task<ICollection<User>> GetAllActiveUsersAsync();
        Task<ICollection<User>> GetAllInactiveUsersAsync();
        Task<ICollection<User>> GetAllByRegistrationDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<ICollection<User>> GetAllByLastLoginDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}

