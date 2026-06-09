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
            if (await _unitOfWork.MembershipPlans.ExistByNameAsync(dto.Name))
            {
                throw new InvalidOperationException("Membership plan with this name already exists");
            }

            if (dto.IsActive != true)
            {
                throw new InvalidOperationException("New membership plan must be active");
            }

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
                throw new KeyNotFoundException("Membership plan not found");
            }

            if (await _unitOfWork.Memberships.AnyActiveByMembershipPlanIdAsync(id))
            {
                throw new InvalidOperationException("Cannot delete membership plan with active memberships");
            }

            await _unitOfWork.MembershipPlans.DeleteAsync(membershipPlan);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<MembershipPlanDto> DuplicatePlanAsync(int sourcePlanId, string newPlanName)
        { 
            var sourcePlan = await _unitOfWork.MembershipPlans.GetByIdAsync(sourcePlanId);

            if (sourcePlan == null)
                throw new KeyNotFoundException("Source membership plan not found");

            if (await _unitOfWork.MembershipPlans.ExistByNameAsync(newPlanName))
                throw new InvalidOperationException("Membership plan with this name already exists");

            var newPlan = new MembershipPlan(newPlanName, sourcePlan.Description, sourcePlan.Price, sourcePlan.DurationInDays);

            await _unitOfWork.MembershipPlans.AddAsync(newPlan);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<MembershipPlanDto>(newPlan);
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

        public async Task<MembershipPlanDto> GetMembershipPlanAsync(int id)
        {
            var membershipPlan = await _unitOfWork.MembershipPlans.GetByIdAsync(id);

            if (membershipPlan == null)
                throw new KeyNotFoundException("Membership plan not found");

            return _mapper.Map<MembershipPlanDto>(membershipPlan);
        }

        public async Task UpdateMembershipPlanAsync(int id, UpdateMembershipPlanDto dto)
        {
            var membershipPlan = await _unitOfWork.MembershipPlans.GetByIdAsync(id);

            if (membershipPlan == null)
            {
                throw new KeyNotFoundException("Membership plan not found");
            }

            if (await _unitOfWork.MembershipPlans.ExistByNameAsync(dto.Name))
                throw new InvalidOperationException("Membership plan with this name already exists");

            _mapper.Map(dto, membershipPlan);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdatePlanPriceAsync(int id, decimal newPrice)
        {
            var membershipPlan = await _unitOfWork.MembershipPlans.GetByIdAsync(id);

            if (membershipPlan == null)
            {
                throw new KeyNotFoundException("Membership plan not found");
            }

            if (newPrice <= 0)
                throw new InvalidOperationException("Price cannot be negative or equal cero");

            membershipPlan.ChangePrice(newPrice);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
