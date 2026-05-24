using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Infrastructure.Persistence.Context;

namespace FitControl.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FitControlDbContext _context;

        public UserRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user) => await _context.Users.AddAsync(user);
        public async Task DeleteAsync(User user) => _context.Users.Remove(user);
        public async Task<ICollection<User>> GetActiveUsersAsync() => await _context.Users.Where(u => u.IsActive == true).ToListAsync();
        public async Task<IEnumerable<User>> GetAllAsync() => await _context.Users.ToListAsync();
        public async Task<User?> GetByEmailAsync(string email) => await _context.Users.FirstOrDefaultAsync(u => u.Email.Value == email);
        public async Task<User?> GetByIdAsync(int id) => await _context.Users.FindAsync(id);
        public async Task<ICollection<User>> GetByLastLoginDateRangeAsync(DateTime startDate, DateTime endDate) => await _context.Users.Where(u => u.LastLoginAt >= startDate && u.LastLoginAt <= endDate).ToListAsync();
        public async Task<User?> GetByUserNameAsync(string name) => await _context.Users.FirstOrDefaultAsync(u => u.UserName == name);
        public async Task<ICollection<User>> GetByRegistrationDateRangeAsync(DateTime startDate, DateTime endDate) => await _context.Users.Where(u => u.CreatedAt >= startDate && u.CreatedAt <= endDate).ToListAsync();
        public async Task<User?> GetByUsernameAsync(string username) => await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        public async Task<ICollection<User>> GetInactiveUsersAsync() => await _context.Users.Where(u => u.IsActive == false).ToListAsync();
        public async Task UpdateAsync(User entity) => _context.Users.Update(entity);
    }
}
