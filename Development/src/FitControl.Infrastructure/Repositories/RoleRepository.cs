using Microsoft.EntityFrameworkCore;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Domain.Entities;
using FitControl.Infrastructure.Persistence.Context;
using FitControl.Application.Common;

namespace FitControl.Infrastructure.Repositories
{
    internal class RoleRepository : IRoleRepository
    {
        private readonly FitControlDbContext _context;

        public RoleRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Role role) => await _context.Roles.AddAsync(role);
        public async Task DeleteAsync(Role role) => _context.Roles.Remove(role);
        public async Task<bool> ExistsNameAsync(string name) => await _context.Roles.AnyAsync(r => r.Name.ToLower() == name.ToLower());
        public async Task<ICollection<Role>> GetAllAsync() => await _context.Roles.ToListAsync();
        public async Task<Role?> GetByIdAsync(int id) => await _context.Roles.FindAsync(id);
        public async Task<Role?> GetByNameAsync(string roleName) => await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        public async Task<ICollection<Role>> GetByUserId(int userId) => await _context.Roles.Where(r => r.UserRoles.Any(ur => ur.UserId == userId)).ToListAsync();

        public Task<PagedResult<Role>> GetPagedAsync(PaginationParams paginationParams)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Role role) => _context.Roles.Update(role);

    }
}
