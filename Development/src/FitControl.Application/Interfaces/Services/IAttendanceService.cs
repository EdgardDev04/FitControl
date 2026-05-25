using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces.Services
{
    public interface IAttendanceService
    {
        Task RegisterCheckIn(int memberId);
        Task RegisterCheckOut(int memberId);
        Task<IEnumerable<AttendanceDto>> GetActiveMembersNowAsync();
        Task<ICollection<AttendanceDto>> GetAttendanceByMemberIdAsync(int memberId);
    }
}
