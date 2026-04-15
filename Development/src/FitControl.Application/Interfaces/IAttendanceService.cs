using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces
{
    public interface IAttendanceService
    {
        Task CheckInAsync(int memberId);

        Task CheckOutAsync(int attendanceId);

        Task<IEnumerable<AttendanceDto>> GetMemberAttendancesAsync(int memberId);

        Task<IEnumerable<AttendanceDto>> GetAttendancesByDateAsync(DateTime date);

        Task<bool> IsMemberInsideGymAsync(int memberId);
    }
}
