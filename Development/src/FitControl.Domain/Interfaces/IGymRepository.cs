using FitControl.Domain.Common;
using FitControl.Domain.Entities;

namespace FitControl.Domain.Interfaces
{
    public interface IGymRepository : IGenericRepository<Gym>
    {
        Task GetAllMembersAsync(int gymId);
        Task GetAllTrainersAsync(int gymId);
        Task GetAllAttendancesAsync(int gymId);
        Task GetAllBookingsAsync(int gymId);
    }
}
