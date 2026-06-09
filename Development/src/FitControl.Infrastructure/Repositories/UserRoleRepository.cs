using FitControl.Application.Common;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Domain.Entities;
using FitControl.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FitControl.Infrastructure.Repositories
{
    internal class UserRoleRepository : IUserRoleRepository
    {
        private readonly FitControlDbContext _context;

        public UserRoleRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserRole userRole) => await _context.UserRoles.AddAsync(userRole);

        public async Task DeleteAsync(int userId, int roleId) => await _context.UserRoles.Where(x => x.UserId == userId && x.RoleId == roleId).ExecuteDeleteAsync();

        public async Task DeleteAsync(UserRole entity) => await _context.UserRoles.Where(x => x.UserId == entity.UserId && x.RoleId == entity.RoleId).ExecuteDeleteAsync();
        public async Task<ICollection<UserRole>> GetAllAsync() => await _context.UserRoles.ToListAsync();
        public async Task<UserRole?> GetByIdAsync(int id) => await _context.UserRoles.FindAsync(id);

        public Task<PagedResult<UserRole>> GetPagedAsync(PaginationParams paginationParams)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UserRole userRole) => _context.UserRoles.Update(userRole);
        public async Task<bool> UserHasRoleAsync(int userId, int roleId) => await _context.UserRoles.AnyAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
    }
}
