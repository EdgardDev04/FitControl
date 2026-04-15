using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces
{
    public interface ITrainerService
    {
        Task CreateTrainerAsync(CreateTrainerDto dto);
        Task UpdateTrainerAsync(int trainerId, UpdateTrainerDto dto);
        Task DeleteTrainerAsync(int trainerId);
        Task<TrainerDto?> GetTrainerByIdAsync(int trainerId);
        Task<IEnumerable<TrainerDto>> GetAllTrainersAsync();
        Task<IEnumerable<TrainerDto>> SearchTrainersAsync(string searchTerm);
        Task ActivateTrainerAsync(int trainerId);
        Task DeactivateTrainerAsync(int trainerId);
    }
}
