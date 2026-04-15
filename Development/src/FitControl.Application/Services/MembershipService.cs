using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Domain.Entities;
using FitControl.Domain.Enums;
using FitControl.Domain.Interfaces;

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

        public async Task ActiveMembershipAsync(int membershipId)
        {
            var membership = await _unitOfWork.Memberships.GetByIdAsync(membershipId);

            if (membership == null)
                throw new KeyNotFoundException($"Membership with ID {membershipId} not found.");

            membership.MarkAsActive();

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task CancelMembershipAsync(int membershipId)
        {
            var membership = await _unitOfWork.Memberships.GetByIdAsync(membershipId);

            if (membership == null) 
                throw new KeyNotFoundException($"Membership with ID {membershipId} not found.");

            membership.MarkAsCancelled();

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task CreateMembershipAsync(CreateMembershipDto dto)
        {
            var membership = _mapper.Map<Membership>(dto);

            await _unitOfWork.Memberships.AddAsync(membership);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task ExpiredMembershipAsync(int membershipId)
        {
            var membership = await _unitOfWork.Memberships.GetByIdAsync(membershipId);

            if (membership == null)
                throw new KeyNotFoundException($"Membership with ID {membershipId} not found.");

            membership.MarkAsExpired();

            await _unitOfWork.SaveChangesAsync();
        }

        public Task<MembershipDto?> GetActiveMembershipAsync(int memberId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MembershipDto>> GetMemberMembershipsAsync(int memberId)
        {
            var memberships = _unitOfWork.Memberships.GetAllByMemberIdAsync(memberId);

            if (memberships == null)
                throw new KeyNotFoundException($"No memberships found for member with ID {memberId}.");

            return _mapper.Map<IEnumerable<MembershipDto>>(memberships);
        }

        public async Task<MembershipDto?> GetMembershipByIdAsync(int membershipId)
        {
            var membership = await _unitOfWork.Memberships.GetByIdAsync(membershipId);

            if (membership == null)
                return null;

            return _mapper.Map<MembershipDto>(membership);
        }

        public async Task<bool> HasActiveMembershipAsync(int memberId)
        {
           var activeMembership = await _unitOfWork.Memberships.GetByMemberIdAsync(memberId);
            
            if (activeMembership == null)
                return false;

            return activeMembership.GetStatus() == MembershipStatus.Active; 
        }

        public async Task InactiveMembershipAsync(int membershipId)
        {
            var membership = await _unitOfWork.Memberships.GetByIdAsync(membershipId);

            if (membership == null)
                throw new KeyNotFoundException($"Membership with ID {membershipId} not found.");

            membership.MarkAsInactive();

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task PendingPaymentMembershipAsync(int membershipId)
        {
            var membership = await _unitOfWork.Memberships.GetByIdAsync(membershipId);

            if (membership == null)
                throw new KeyNotFoundException($"Membership with ID {membershipId} not found.");

            membership.MarkAsPendingPayment();

            await _unitOfWork.SaveChangesAsync();
        }

        public Task RenewMembershipAsync(int membershipId)
        {
            throw new NotImplementedException();
        }

        public async Task SuspendedMembershipAsync(int membershipId)
        {
            var membership = await _unitOfWork.Memberships.GetByIdAsync(membershipId);

            if (membership == null)
                throw new KeyNotFoundException($"Membership with ID {membershipId} not found.");

            membership.MarkAsSuspended();

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
