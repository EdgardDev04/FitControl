using FitControl.Domain.Entities;
using FitControl.Domain.Enums;
using FitControl.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using FitControl.Infrastructure.Persistence.Context;

namespace FitControl.Infrastructure.Repositories
{
    internal class ClassBookingRepository : IClassBookingRepository
    {
        private readonly FitControlDbContext _context;

        public ClassBookingRepository() { }

        public ClassBookingRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ClassBooking entity) => await _context.ClassBookings.AddAsync(entity);

        public async Task DeleteAsync(ClassBooking entity) => _context.ClassBookings.Remove(entity);

        public async Task<IEnumerable<ClassBooking>> GetAllAsync() => await _context.ClassBookings.AsNoTracking().ToListAsync();

        public async Task GetByDateAsync(DateTime date) => await _context.ClassBookings.AsNoTracking().FirstOrDefaultAsync(cb => cb.BookingDate == date);

        public async Task<ClassBooking?> GetByIdAsync(int id) => await _context.ClassBookings.FindAsync(id);

        public async Task<IEnumerable<ClassBooking>> GetAllByMemberIdAsync(int memberId) => await _context.ClassBookings.AsNoTracking().Where(cb => cb.MemberId == memberId).ToListAsync();

        public async Task<IEnumerable<ClassBooking>> GetAllByClassSessionIdAsync(int classSessionId) => await _context.ClassBookings.AsNoTracking().Where(cb => cb.ClassSessionId == classSessionId).ToListAsync();

        public async Task<IEnumerable<ClassBooking>>GetAllByStatusAsync(BookingStatus status) => await _context.ClassBookings.AsNoTracking().Where(cb => cb.Status == status).ToListAsync();

        public async Task UpdateAsync(ClassBooking entity) => _context.ClassBookings.Update(entity);

        public async Task<bool> ExistBookingAsync(int memberId, int classSessionId) => await _context.ClassBookings.AnyAsync(cb => cb.MemberId == memberId && cb.ClassSessionId == classSessionId);
    }
}
