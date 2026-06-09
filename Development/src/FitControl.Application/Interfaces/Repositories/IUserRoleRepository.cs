using FitControl.Application.Common;
using FitControl.Domain.Entities;

namespace FitControl.Application.Interfaces.Repositories
{
    public interface IUserRoleRepository : IRepositoryBase<UserRole>
    {
        Task<bool> UserHasRoleAsync(int userId, int roleId);
        Task DeleteAsync(int userId, int roleId);
    }
}
