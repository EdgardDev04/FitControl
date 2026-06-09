using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Infrastructure.Persistence.Context;
using FitControl.Application.Common;

namespace FitControl.Infrastructure.Repositories
{
    internal class AttendanceRepository : IAttendanceRepository
    {
        private readonly FitControlDbContext _context;

        public AttendanceRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Attendance attendance) => await _context.Attendances.AddAsync(attendance);
        public async Task<bool> HasAnyActiveAttendanceAsync(int memberId) => await _context.Attendances.AsNoTracking().AnyAsync(a => a.MemberId == memberId && a.CheckOutTime == null);  
        public async Task DeleteAsync(Attendance attendance) => _context.Attendances.Remove(attendance);
        public async Task<ICollection<Attendance>> GetAllAsync() => await _context.Attendances.AsNoTracking().ToListAsync();
        public async Task<ICollection<Attendance>> GetAllByMemberIdAsync(int memberId) => await _context.Attendances.AsNoTracking().Where(a => a.MemberId == memberId).ToListAsync();
        public async Task<Attendance?> GetByIdAsync(int id) => await _context.Attendances.FindAsync(id);
        public async Task UpdateAsync(Attendance attendance) => _context.Attendances.Update(attendance);
        public async Task<Attendance> GetByMemberIdAsync(int memberId) => await _context.Attendances.FirstOrDefaultAsync(a => a.MemberId == memberId);
        public async Task<Attendance> GetActiveAttendanceAsync(int memberId) => await _context.Attendances.FirstOrDefaultAsync(a => a.MemberId == memberId && a.CheckOutTime == null);
        public async Task<ICollection<Attendance>> GetAllByDateRangeAsync(DateTime startDate, DateTime endDate) => await _context.Attendances.AsNoTracking().Where(a => a.CheckInTime >= startDate && a.CheckInTime <= endDate).ToListAsync();

        public Task<PagedResult<Attendance>> GetPagedAsync(PaginationParams paginationParams)
        {
            throw new NotImplementedException();
        }
    }
}
