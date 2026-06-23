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

        public async Task AddAsync(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
        }

        public async Task DeleteAsync(int userId, int roleId)
        {
            await _context.UserRoles.Where(x => x.UserId == userId && x.RoleId == roleId).ExecuteDeleteAsync();
        }

        public async Task DeleteAsync(UserRole entity)
        {
            await _context.UserRoles.Where(x => x.UserId == entity.UserId && x.RoleId == entity.RoleId).ExecuteDeleteAsync();
        }

        public async Task<ICollection<UserRole>> GetAllAsync()
        {
            return await _context.UserRoles.ToListAsync();
        }

        public async Task<UserRole?> GetByIdAsync(int id) 
        {
            return await _context.UserRoles.FindAsync(id);
        }

        public async Task<PagedResult<UserRole>> GetPagedAsync(PaginationParams paginationParams)
        {
            var query = _context.UserRoles.AsNoTracking();

            var totalCount = await query.CountAsync();

            var userRoles = await query
                .OrderBy(a => a.UserId)
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<UserRole>
            {
                Items = userRoles,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)paginationParams.PageSize)
            };
        }

        public async Task UpdateAsync(UserRole userRole)
        {
            _context.UserRoles.Update(userRole);
        }

        public async Task<bool> UserHasRoleAsync(int userId, int roleId) 
        {
            return await _context.UserRoles.AnyAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
        }
    }
}
