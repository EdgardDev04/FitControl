using AutoMapper;
using AutoMapper.Execution;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Application.Interfaces.Services;
using FitControl.Domain.Entities;
using FitControl.Domain.Enums;

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

        public async Task<PromotionDto> CreatePromotionAsync(CreatePromotionDto dto)
        {
            var promotion = _mapper.Map<Promotion>(dto);

            await _unitOfWork.Promotions.AddAsync(promotion);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<PromotionDto>(promotion);
        }

        public async Task DeletePromotionAsync(int id)
        {
            var promotion = await _unitOfWork.Promotions.GetByIdAsync(id);

            if (promotion == null)
            {
                return;
            }

            await _unitOfWork.Promotions.DeleteAsync(promotion);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ICollection<PromotionDto>> GetActivePromotionsAsync()
        {
            var activePromotions = await _unitOfWork.Promotions.GetAllActiveAsync();

            if (activePromotions == null)
            {
                return new List<PromotionDto>();
            }

            return _mapper.Map<ICollection<PromotionDto>>(activePromotions);
        }

        public async Task<ICollection<PromotionDto>> GetAllPromotionsAsync()
        {
            var promotions = await _unitOfWork.Promotions.GetAllAsync();

            if (promotions == null)
            {
                return new List<PromotionDto>();
            }

            return _mapper.Map<ICollection<PromotionDto>>(promotions);
        }

        public async Task<PromotionDto> GetPromotionByIdAsync(int id)
        { 
            var promotion = await _unitOfWork.Promotions.GetByIdAsync(id);

            if ( promotion == null)
            {
                throw new KeyNotFoundException("Promotions is not found");
            }

            return _mapper.Map<PromotionDto>(promotion);
        }

        public async Task<ICollection<PromotionDto>> GetPromotionsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var promotions = await _unitOfWork.Promotions.GetAllByDateRangeAsync(startDate, endDate);

            if (promotions == null)
            {
                return new List<PromotionDto>();
            }

            return _mapper.Map<ICollection<PromotionDto>>(promotions);
        }

        public async Task<ICollection<PromotionDto>> GetPromotionsByMembershipPlanIdAsync(int membershipPlanId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<PromotionDto>> GetPromotionsByStatusAsync(PromotionStatus status)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<PromotionDto>> GetPromotionsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePromotionAsync(int Id, UpdatePromotionDto dto)
        {
            var promotion =  await _unitOfWork.Promotions.GetByIdAsync(Id);
            
            if (promotion == null)
            {
                throw new KeyNotFoundException();
            }

            _mapper.Map(dto, promotion);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
