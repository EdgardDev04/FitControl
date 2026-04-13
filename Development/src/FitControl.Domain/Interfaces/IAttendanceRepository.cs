using FitControl.Domain.Common;
using FitControl.Domain.Entities;

namespace FitControl.Domain.Interfaces
{
    public interface IAttendanceRepository : IGenericRepository<Attendance>
    {
        Task GetCheckInTimeAsync(int memberId, int gymId);
    }
}
