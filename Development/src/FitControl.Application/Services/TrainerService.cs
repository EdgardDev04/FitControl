using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Domain.Entities;
using FitControl.Domain.Interfaces;

namespace FitControl.Application.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TrainerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task ActivateTrainerAsync(int trainerId)
        {
            var trainer = await _unitOfWork.Trainers.GetByIdAsync(trainerId);

            if (trainer == null)
                throw new KeyNotFoundException();

            trainer.MarkAsActive();

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task CreateTrainerAsync(CreateTrainerDto dto)
        {
            var trainer = _mapper.Map<Trainer>(dto);

            await _unitOfWork.Trainers.AddAsync(trainer);

            await _unitOfWork.SaveChangesAsync();

        }

        public async Task DeactivateTrainerAsync(int trainerId)
        {
            var trainer = await _unitOfWork.Trainers.GetByIdAsync(trainerId);

            if (trainer == null)
                throw new KeyNotFoundException();

            trainer.MarkAsInactive();

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteTrainerAsync(int trainerId)
        {
            var trainer = await _unitOfWork.Trainers.GetByIdAsync(trainerId);

            if (trainer == null)
                throw new KeyNotFoundException();

            await _unitOfWork.Trainers.DeleteAsync(trainer);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<TrainerDto>> GetAllTrainersAsync()
        {
            var trainers = await _unitOfWork.Trainers.GetAllAsync();

            if (trainers == null)
                return new List<TrainerDto>();

            return _mapper.Map<IEnumerable<TrainerDto>>(trainers);
        }

        public async Task<TrainerDto?> GetTrainerByIdAsync(int trainerId)
        {
            var trainer = await _unitOfWork.Trainers.GetByIdAsync(trainerId);

            if (trainer == null)
                return null;

            return _mapper.Map<TrainerDto>(trainer);
        }

        public Task<IEnumerable<TrainerDto>> SearchTrainersAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateTrainerAsync(int trainerId, UpdateTrainerDto dto)
        {
            var trainer = await _unitOfWork.Trainers.GetByIdAsync(trainerId);

            if (trainer == null)
                throw new KeyNotFoundException();

            _mapper.Map(dto, trainer);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
