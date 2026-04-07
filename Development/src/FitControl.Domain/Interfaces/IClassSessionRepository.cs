using FitControl.Domain.Common;
using FitControl.Domain.Entities;
using FitControl.Domain.Enums;

namespace FitControl.Domain.Interfaces
{
    public interface IClassSessionRepository : IGenericRepository<ClassSession>
    {
        Task GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task GetByStatusAsync(ClassSessionStatus status);
        Task GetByTrainerIdAsync(int trainerId);
        Task GetByClassTypeIdAsync(int classTypeId);
    }
}
