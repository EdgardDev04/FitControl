using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces.Services
{
    public interface IAttendanceService
    {
        Task RegisterCheckInAsync(int memberId);
        Task RegisterCheckOutAsync(int memberId);
        Task<AttendanceDto> GetAttendanceAsync(int id);
        Task<ICollection<AttendanceDto>> GetAllAttendancesAsync();
        Task<ICollection<AttendanceDto>> GetRegisterMembersTodayAsync();
        Task<ICollection<AttendanceDto>> GetAttendanceByMemberIdAsync(int memberId);
        Task<ICollection<AttendanceDto>> GetAttendanceByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task DeleteAttendanceAsync(int attendanceId);
    }
}
