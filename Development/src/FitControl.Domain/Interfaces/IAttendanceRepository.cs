using FitControl.Domain.Common;
using FitControl.Domain.Entities;

namespace FitControl.Domain.Interfaces
{
    public interface IAttendanceRepository : IGenericRepository<Attendance>
    {
        Task GetCheckInTimeAsync(int memberId, int gymId);
        Task<IEnumerable<Attendance>> GetAttendancesByDateAsync(DateTime date);
        Task<IEnumerable<Attendance>> GetAttendancesByMemberIdAsync(int memberId);
    }
}
