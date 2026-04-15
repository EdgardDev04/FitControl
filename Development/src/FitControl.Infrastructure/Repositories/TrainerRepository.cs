using FitControl.Domain.Entities;
using FitControl.Domain.Enums;
using FitControl.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using FitControl.Infrastructure.Persistence.Context;

namespace FitControl.Infrastructure.Repositories
{
    internal class TrainerRepository : ITrainerRepository
    {
        private readonly FitControlDbContext _context;

        public TrainerRepository() { }

        public TrainerRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Trainer entity) => await _context.Trainers.AddAsync(entity);

        public async Task DeleteAsync(Trainer entity) => _context.Trainers.Remove(entity);

        public async Task<IEnumerable<Trainer>> GetAllAsync() => await _context.Trainers.AsNoTracking().ToListAsync();

        public async Task<Trainer?> GetByIdAsync(int id) => await _context.Trainers.FindAsync(id);

        public async Task GetByNameAsync(string name) => await _context.Trainers.AsNoTracking().FirstOrDefaultAsync(t => t.Name == name);

        public async Task GetBySpecialtyAsync(string specialty) => await _context.Trainers.AsNoTracking().Where(t => t.Specialty == specialty).ToListAsync();

        public async Task GetByStatusAsync(TrainerStatus status) => await _context.Trainers.Where(t => t.Status == status).ToListAsync();

        public async Task UpdateAsync(Trainer entity) => _context.Trainers.Update(entity);
    }
}
