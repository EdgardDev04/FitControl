using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces.Services
{
    public interface IRoleService
    {
        Task<ICollection<RoleDto>> GetAllRoleAsync();
        Task<RoleDto?> GetRoleAsync(int id);
        Task<RoleDto?> GetByNameAsync(string roleName);
        Task<RoleDto> CreateAsync(string name);
        Task UpdateRoleAsync(int id, string name);
        Task DeleteRoleAsync(int id);
        Task<bool> AssignRoleToUserAsync(int userId, int roleId);
        Task<bool> RemoveRoleFromUserAsync(int userId, int roleId);
    }
}
