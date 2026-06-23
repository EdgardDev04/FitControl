using AutoMapper;
using FitControl.Application.Common;
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

        public Task<decimal> CalculateDiscountedPriceAsync(decimal basePrice, string promoCode)
        {
            throw new NotImplementedException();
        }

        public async Task<PromotionDto> CreatePromotionAsync(CreatePromotionDto dto)
        {
            if(await _unitOfWork.Promotions.ExistsByName(dto.Name))
            {
                throw new InvalidOperationException("Promotion code already exists.");
            }

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

        public async Task<PagedResult<PromotionDto>> GetPagedPromotionsAsync(PaginationParams paginationParams)
        {
            var pagedPromotions = await _unitOfWork.Promotions.GetPagedAsync(paginationParams);

            return new PagedResult<PromotionDto>
            {
                Items = _mapper.Map<IEnumerable<PromotionDto>>(pagedPromotions.Items),
                PageNumber = pagedPromotions.PageNumber,
                PageSize = pagedPromotions.PageSize,
                TotalCount = pagedPromotions.TotalCount,
                TotalPages = pagedPromotions.TotalPages
            };
        }

        public async Task<PromotionDto> GetPromotionAsync(int id)
        {
            var promotion = await _unitOfWork.Promotions.GetByIdAsync(id);

            if (promotion == null)
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
            var promotions = await _unitOfWork.Promotions.GetAllByStatusAsync(status);

            if ( promotions == null)
            {
                return new List<PromotionDto>();
            }

            return _mapper.Map<ICollection<PromotionDto>>(promotions);
        }

        public async Task UpdatePromotionAsync(int Id, UpdatePromotionDto dto)
        {
            var promotion =  await _unitOfWork.Promotions.GetByIdAsync(Id);
            
            if (promotion == null)
            {
                throw new KeyNotFoundException();
            }

            if (await _unitOfWork.Promotions.ExistsByName(dto.Name))
            {
                throw new InvalidOperationException("Promotion code already exists.");
            }

            _mapper.Map(dto, promotion);

            await _unitOfWork.SaveChangesAsync();
        }

        public Task<PromotionValidationResultDto> ValidatePromotionCodeAsync(string code, int memberId, int? planId = null)
        {
            throw new NotImplementedException();
        }
    }
}
