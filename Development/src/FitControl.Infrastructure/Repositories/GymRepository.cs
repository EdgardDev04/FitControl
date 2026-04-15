using FitControl.Domain.Entities;
using FitControl.Domain.Interfaces;
using FitControl.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FitControl.Infrastructure.Repositories
{
    internal class GymRepository : IGymRepository
    {
        private readonly FitControlDbContext _context;

        public GymRepository() { }

        public GymRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Gym entity) => await _context.Gyms.AddAsync(entity);

        public async Task DeleteAsync(Gym entity) =>  _context.Gyms.Remove(entity);

        public async Task<IEnumerable<Gym>> GetAllAsync() => await _context.Gyms.AsNoTracking().ToListAsync();

        public async Task GetAllAttendancesAsync(int gymId) => await _context.Gyms.AsNoTracking().Include(g => g.Attendances).ToListAsync();

        public async Task GetAllBookingsAsync(int gymId) => await _context.Gyms.AsNoTracking().Include(g => g.Bookings).ToListAsync();

        public async Task GetAllMembersAsync(int gymId) => await _context.Gyms.AsNoTracking().Include(g => g.Members).ToListAsync();

        public async Task GetAllTrainersAsync(int gymId) => await _context.Gyms.AsNoTracking().Include(g => g.Trainers).ToListAsync();

        public async Task<Gym?> GetByIdAsync(int id) => await _context.Gyms.FindAsync(id);

        public async Task UpdateAsync(Gym entity) => _context.Gyms.Update(entity);
    }
}
