using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Application.Interfaces.Services;
using FitControl.Domain.Entities;

namespace FitControl.Application.Services
{
    public class MembershipPlanService : IMembershipPlanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MembershipPlanService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MembershipPlanDto> CreateMembershipPlanAsync(CreateMembershipPlanDto dto)
        {
            var membershipPlan = _mapper.Map<MembershipPlan>(dto);

            await _unitOfWork.MembershipPlans.AddAsync(membershipPlan);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<MembershipPlanDto>(membershipPlan);
        }

        public async Task DeleteMembershipPlanAsync(int id)
        {
            var membershipPlan = await _unitOfWork.MembershipPlans.GetByIdAsync(id);

            if (membershipPlan == null)
            {
                throw new InvalidOperationException("Membership plan not found");
            }

            await _unitOfWork.MembershipPlans.DeleteAsync(membershipPlan);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ICollection<MembershipPlanDto>> GetActivePlansAsync()
        {
            var membershipPlans = await _unitOfWork.MembershipPlans.GetAllActiveAsync();

            if (membershipPlans == null)
            {
                return new List<MembershipPlanDto>();
            }

            return _mapper.Map<ICollection<MembershipPlanDto>>(membershipPlans);
        }

        public async Task<ICollection<MembershipPlanDto>> GetAllMembershipPlanAsync()
        {
            var membershipPlans = await _unitOfWork.MembershipPlans.GetAllAsync();

            if (membershipPlans == null)
            {
                return new List<MembershipPlanDto>();
            }

            return _mapper.Map<ICollection<MembershipPlanDto>>(membershipPlans);
        }

        public async Task<ICollection<MembershipPlanDto>> GetInactivePlansAsync()
        {
            var membershipPlans = await _unitOfWork.MembershipPlans.GetAllInactiveAsync();

            if (membershipPlans == null)
            {
                return new List<MembershipPlanDto>();
            }

            return _mapper.Map<ICollection<MembershipPlanDto>>(membershipPlans);
        }

        public async Task<MembershipPlanDto> GetMembershipPlanByIdAsync(int id)
        {
            var membershipPlan = await _unitOfWork.MembershipPlans.GetByIdAsync(id);

            if (membershipPlan == null)
            {
                return null;
            }

            return _mapper.Map<MembershipPlanDto>(membershipPlan);
        }

        public async Task UpdateMembershipPlanAsync(int id, UpdateMembershipPlanDto dto)
        {
            var membershipPlan = await _unitOfWork.MembershipPlans.GetByIdAsync(id);

            if (membershipPlan == null)
            {
                throw new InvalidOperationException("Membership plan not found");
            }

            _mapper.Map(dto, membershipPlan);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdatePlanPriceAsync(int id, decimal newPrice)
        {
            var membershipPlan = await _unitOfWork.MembershipPlans.GetByIdAsync(id);

            if (membershipPlan == null)
            {
                throw new InvalidOperationException("Membership plan not found");
            }

            membershipPlan.ChangePrice(newPrice);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
