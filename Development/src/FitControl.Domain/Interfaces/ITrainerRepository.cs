using FitControl.Domain.Common;
using FitControl.Domain.Entities;
using FitControl.Domain.Enums;

namespace FitControl.Domain.Interfaces
{
    public interface ITrainerRepository : IGenericRepository<Trainer>
    {
        Task GetByNameAsync(string name);
        Task GetBySpecialtyAsync(string specialty);
        Task GetByStatusAsync(TrainerStatus status);
    }
}
