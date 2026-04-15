using FitControl.Domain.Common;
using FitControl.Domain.Entities;
using FitControl.Domain.Enums;

namespace FitControl.Domain.Interfaces
{
    public interface IClassBookingRepository : IGenericRepository<ClassBooking>
    {
        Task GetByDateAsync(DateTime date);
        Task<IEnumerable<ClassBooking>> GetAllByStatusAsync(BookingStatus status);
        Task<IEnumerable<ClassBooking>> GetAllByMemberIdAsync(int memberId);
        Task<IEnumerable<ClassBooking>> GetAllByClassSessionIdAsync(int classSessionId);
        Task<bool> ExistBookingAsync(int memberId, int classSessionId);
    }
}
