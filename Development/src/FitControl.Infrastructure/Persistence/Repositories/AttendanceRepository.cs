using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Infrastructure.Persistence.Context;

namespace FitControl.Infrastructure.Persistence.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly FitControlDbContext _context;

        public AttendanceRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Attendance attendance) => await _context.Attendances.AddAsync(attendance);
        public async Task DeleteAsync(Attendance attendance) => _context.Attendances.Remove(attendance);
        public async Task<IEnumerable<Attendance>> GetAllAsync() => await _context.Attendances.ToListAsync();
        public async Task<Attendance?> GetByIdAsync(int id) => await _context.Attendances.FindAsync(id);
        public async Task UpdateAsync(Attendance attendance) => _context.Attendances.Update(attendance);
        
    }
}
