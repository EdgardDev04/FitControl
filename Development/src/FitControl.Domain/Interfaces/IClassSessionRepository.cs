using FitControl.Domain.Common;
using FitControl.Domain.Entities;
using FitControl.Domain.Enums;

namespace FitControl.Domain.Interfaces
{
    public interface IClassSessionRepository : IGenericRepository<ClassSession>
    {
        Task GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<ClassSession>> GetAllByStatusAsync(ClassSessionStatus status);
        Task<IEnumerable<ClassSession>> GetAllByTrainerIdAsync(int trainerId);
        Task<IEnumerable<ClassSession>> GetAllByClassTypeIdAsync(int classTypeId);
    }
}
