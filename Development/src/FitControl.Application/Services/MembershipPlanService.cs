using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Domain.Entities;
using FitControl.Domain.Interfaces;

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

        public async Task<IEnumerable<MembershipPlanDto>> ActivateMembershipPlanAsync()
        {
            var membershipPlans = await _unitOfWork.MembershipPlans.GetActivePlanAsync();

            if (membershipPlans == null)
                return new List<MembershipPlanDto>();

            return _mapper.Map<IEnumerable<MembershipPlanDto>>(membershipPlans);
        }

        public async Task CreateMembershipPlanAsync(CreateMembershipPlanDto dto)
        {
            var membershipPlan = _mapper.Map<MembershipPlan>(dto);

            await _unitOfWork.MembershipPlans.AddAsync(membershipPlan);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeactivateMembershipPlanAsync(int planId)
        {
            var membershipPlan = await _unitOfWork.MembershipPlans.GetByIdAsync(planId);

            if (membershipPlan == null)
                throw new KeyNotFoundException($"Membership plan with ID {planId} not found.");

            membershipPlan.MarkAsInactive();

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteMembershipPlanAsync(int planId)
        {
            var membershipPlan = await _unitOfWork.MembershipPlans.GetByIdAsync(planId);

            if (membershipPlan == null)
                throw new KeyNotFoundException($"Membership plan with ID {planId} not found.");


            await _unitOfWork.MembershipPlans.DeleteAsync(membershipPlan);
        
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<MembershipPlanDto>> GetAllMembershipPlansAsync()
        {
            var membershipPlans = await _unitOfWork.MembershipPlans.GetAllAsync();

            if (membershipPlans == null)
                return new List<MembershipPlanDto>();

            return _mapper.Map<IEnumerable<MembershipPlanDto>>(membershipPlans);
        }

        public async Task<MembershipPlanDto?> GetMembershipPlanByIdAsync(int planId)
        {
            var membershipPlan = await _unitOfWork.MembershipPlans.GetByIdAsync(planId);

            if (membershipPlan == null)
                return null;

            return _mapper.Map<MembershipPlanDto>(membershipPlan);
        }

        public async Task UpdateMembershipPlanAsync(int planId, UpdateMembershipPlanDto dto)
        {
            var membershipPlan = await _unitOfWork.MembershipPlans.GetByIdAsync(planId);

            if (membershipPlan == null)
                throw new KeyNotFoundException($"Membership plan with ID {planId} not found.");

            _mapper.Map(dto, membershipPlan);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
