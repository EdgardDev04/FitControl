using FitControl.Application.Common;
using FitControl.Domain.Entities;

namespace FitControl.Application.Interfaces.Repositories
{
    public interface IAttendanceRepository : IRepositoryBase<Attendance>
    {
        Task<Attendance> GetByMemberIdAsync(int memberId);
        Task<Attendance> GetActiveAttendanceAsync(int memberId);
        Task<bool> HasAnyActiveAttendanceAsync(int memberId);
        Task<ICollection<Attendance>> GetAllByMemberIdAsync(int memberId);
        Task<ICollection<Attendance>> GetAllByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
