using FitControl.Domain.Entities;
using FitControl.Domain.Enums;
using FitControl.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using FitControl.Infrastructure.Persistence.Context;

namespace FitControl.Infrastructure.Repositories
{
    internal class ClassSessionRepository : IClassSessionRepository
    {
        private readonly FitControlDbContext _context;

        public ClassSessionRepository() { }

        public ClassSessionRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ClassSession entity) => await _context.ClassSessions.AddAsync(entity);

        public async Task DeleteAsync(ClassSession entity) => _context.ClassSessions.Remove(entity);

        public async Task<IEnumerable<ClassSession>> GetAllAsync() => await _context.ClassSessions.ToListAsync();

        public async Task GetByClassTypeIdAsync(int classTypeId) => await _context.ClassSessions.FirstOrDefaultAsync(cs => cs.ClassTypeId == classTypeId);

        public Task GetByDateRangeAsync(DateTime startDate, DateTime endDate) => _context.ClassSessions.Where(cs => cs.StartTime >= startDate && cs.EndTime <= endDate).ToListAsync();      

        public async Task<ClassSession?> GetByIdAsync(int id) => await _context.ClassSessions.FindAsync(id);

        public async Task<IEnumerable<ClassSession>> GetAllByStatusAsync(ClassSessionStatus status) => await _context.ClassSessions.Where(cs => cs.Status == status).ToListAsync();

        public async Task<IEnumerable<ClassSession>> GetAllByTrainerIdAsync(int trainerId) => await _context.ClassSessions.Where(cs => cs.TrainerId == trainerId).ToListAsync();

        public async Task UpdateAsync(ClassSession entity) => _context.ClassSessions.Update(entity);

        public async Task<IEnumerable<ClassSession>> GetAllByClassTypeIdAsync(int classTypeId) => await _context.ClassSessions.Where(cs => cs.ClassTypeId == classTypeId).ToListAsync();
    }
}
