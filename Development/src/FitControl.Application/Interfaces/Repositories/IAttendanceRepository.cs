using FitControl.Application.Common;
using FitControl.Domain.Entities;

namespace FitControl.Application.Interfaces.Repositories
{
    public interface IAttendanceRepository : IRepositoryBase<Attendance>
    {
        Task<ICollection<Attendance>> GetAllByMemberIdAsync(int memberId);
    }
}
