using FitControl.Domain.Entities;
using FitControl.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using FitControl.Infrastructure.Persistence.Context;

namespace FitControl.Infrastructure.Repositories
{
    internal class AttendanceRepository : IAttendanceRepository
    {
        private readonly FitControlDbContext _context;

        public AttendanceRepository() { }

        public AttendanceRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Attendance entity) => await _context.Attendances.AddAsync(entity);

        public async Task DeleteAsync(Attendance entity) => _context.Attendances.Remove(entity);

        public async Task<IEnumerable<Attendance>> GetAllAsync() => await _context.Attendances.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<Attendance>> GetAttendancesByDateAsync(DateTime date) => await _context.Attendances.AsNoTracking().Where(a => a.CheckInTime.Date == date.Date).ToListAsync();

        public async Task<IEnumerable<Attendance>> GetAttendancesByMemberIdAsync(int memberId) => await _context.Attendances.AsNoTracking().Where(a => a.MemberId == memberId).ToListAsync();
        public async Task<Attendance?> GetByIdAsync(int id) => await _context.Attendances.FindAsync(id);

        public async Task GetCheckInTimeAsync(int memberId, int gymId) => await _context.Attendances.AsNoTracking()
                                                                          .Where(a => a.MemberId == memberId && a.GymId == gymId)
                                                                          .OrderByDescending(a => a.CheckInTime)
                                                                          .Select(a => a.CheckInTime)
                                                                          .FirstOrDefaultAsync();
        
        public async Task UpdateAsync(Attendance entity) => _context.Attendances.Update(entity);
    }
}
