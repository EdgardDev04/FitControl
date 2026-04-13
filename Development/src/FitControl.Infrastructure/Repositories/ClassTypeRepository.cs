using FitControl.Domain.Entities;
using FitControl.Domain.Interfaces;
using FitControl.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FitControl.Infrastructure.Repositories
{
    internal class ClassTypeRepository : IClassTypeRepository
    {
        private readonly FitControlDbContext _context;

        public ClassTypeRepository() { }

        public ClassTypeRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ClassType entity) => await _context.ClassTypes.AddAsync(entity);

        public async Task DeleteAsync(ClassType entity) => _context.ClassTypes.Remove(entity);

        public async Task<IEnumerable<ClassType>> GetAllAsync() => await _context.ClassTypes.ToListAsync();

        public async Task<ClassType?> GetByIdAsync(int id) => await _context.ClassTypes.FindAsync(id);

        public async Task<ClassType?> GetByNameAsync(string name) => await _context.ClassTypes.FirstOrDefaultAsync(ct => ct.Name == name);

        public async Task UpdateAsync(ClassType entity) => _context.ClassTypes.Update(entity);
    }
}
