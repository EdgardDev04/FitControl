using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Application.Interfaces.Services;

namespace FitControl.Application.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PromotionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task CreatePromotionAsync(CreatePromotionDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeletePromotionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PromotionDto>> GetActivePromotionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PromotionDto>> GetAllPromotionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PromotionDto> GetPromotionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PromotionDto>> GetPromotionsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PromotionDto>> GetPromotionsByMembershipPlanIdAsync(int membershipPlanId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PromotionDto>> GetPromotionsByStatusAsync(string status)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PromotionDto>> GetPromotionsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePromotionAsync(UpdatePromotionDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
