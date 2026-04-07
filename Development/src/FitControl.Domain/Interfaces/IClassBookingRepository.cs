using FitControl.Domain.Common;
using FitControl.Domain.Entities;
using FitControl.Domain.Enums;

namespace FitControl.Domain.Interfaces
{
    public interface IClassBookingRepository : IGenericRepository<ClassBooking>
    {
        Task GetByDateAsync(DateTime date);
        Task GetByStatusAsync(BookingStatus status);
        Task GetByMemberIdAsync(int memberId);

    }
}
