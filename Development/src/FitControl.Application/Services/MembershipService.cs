using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Application.Interfaces.Services;
using FitControl.Domain.Entities;
using FitControl.Domain.Enums;

namespace FitControl.Application.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MembershipService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task CancelMembershipAsync(int id, CancelMembershipDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<MembershipDto> CreateMembershipAsync(CreateMembershipDto dto)
        {
            var member = await _unitOfWork.Members.GetByIdAsync(dto.MemberId);
            var membershipPlan = await _unitOfWork.MembershipPlans.GetByIdAsync(dto.MembershipPlanId);

            if (membershipPlan == null) 
                throw new KeyNotFoundException("Membership plan not found");

            if (member == null)
                throw new KeyNotFoundException("Member not found");

            if (!membershipPlan.IsActive)
                throw new InvalidOperationException("Membership plan is not active");

            if (!member.IsActive)
                throw new InvalidOperationException("Member is not active");

            var membership = _mapper.Map<Membership>(dto);

            await _unitOfWork.Memberships.AddAsync(membership);

            await _unitOfWork.SaveChangesAsync();
            
            return _mapper.Map<MembershipDto>(membership);
        }

        public async Task DeleteMembershipAsync(int id)
        {
            var membership = await _unitOfWork.Memberships.GetByIdAsync(id);

            if (membership == null)
            {
                throw new InvalidOperationException("Membership not found");
            }

            await _unitOfWork.Memberships.DeleteAsync(membership);

            await _unitOfWork.SaveChangesAsync();
        }

        public Task<MembershipDto> GetActiveMembershipByMemberIdAsync(int memberId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<MembershipDto>> GetAllMembershipAsync()
        {
            var memberships = await _unitOfWork.Memberships.GetAllAsync();

            if (memberships == null)
            {
                return new List<MembershipDto>();
            }

            return _mapper.Map<ICollection<MembershipDto>>(memberships);
        }

        public async Task<MembershipDto> GetMembershipAsync(int id)
        {
            var membership = await _unitOfWork.Memberships.GetByIdAsync(id);

            if (membership == null)
            {
                throw new KeyNotFoundException("Membership not found");
            }

            return _mapper.Map<MembershipDto>(membership);
        }

        public async Task<ICollection<MembershipDto>> GetMembershipByStatusAsync(MembershipStatus status)
        {
            var memberships = await _unitOfWork.Memberships.GetAllByStatusAsync(status);

            if (memberships == null)
            {
                return new List<MembershipDto>();
            }

            return _mapper.Map<ICollection<MembershipDto>>(memberships);
        }

        public async Task<ICollection<MembershipDto>> GetMembershipsByMembershipPlanIdAsync(int membershipPlanId)
        {
            var memberships = await _unitOfWork.Memberships.GetByMembershipPlanIdAsync(membershipPlanId);

            if (memberships == null)
            {
                return new List<MembershipDto>();
            }

            return _mapper.Map<ICollection<MembershipDto>>(memberships);
        }

        public Task<MembershipDto> RenewMembershipAsync(int id, RenewMembershipDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateMembershipAsync(int id, UpdateMembershipDto dto)
        {
            var membership = await _unitOfWork.Memberships.GetByIdAsync(id);

            if (membership == null)
            {
                throw new InvalidOperationException("Membership not found");
            }

            _mapper.Map(dto, membership);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
