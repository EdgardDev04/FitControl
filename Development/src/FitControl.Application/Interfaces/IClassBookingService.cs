using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces
{
    public interface IClassBookingService
    {
        Task BookClassAsync(int memberId, int classSessionId);

        Task CancelBookingAsync(int bookingId);

        Task<IEnumerable<ClassBookingDto>> GetMemberBookingsAsync(int memberId);
        Task<IEnumerable<ClassBookingDto>> GetClassSessionBookingsAsync(int classSessionId);

        Task<bool> IsClassFullAsync(int classSessionId);

        Task ConfirmAttendanceAsync(int bookingId);

    } 
}
