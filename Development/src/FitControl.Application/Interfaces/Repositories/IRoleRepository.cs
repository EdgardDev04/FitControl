using FitControl.Application.Common;
using FitControl.Domain.Entities;

namespace FitControl.Application.Interfaces.Repositories
{
    public interface IRoleRepository : IRepositoryBase<Role>
    {
        Task<bool> ExistsNameAsync(string name);
        Task<ICollection<Role>> GetByUserId(int userId);
        Task<Role?> GetByNameAsync(string roleName);
    }
}
