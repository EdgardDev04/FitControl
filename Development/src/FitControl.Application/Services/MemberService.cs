using AutoMapper;
using FitControl.Domain.Entities;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Application.Interfaces.Services;
using FitControl.Application.Common;

namespace FitControl.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemberService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task ChangeMemberStatusAsync(int id, bool status)
        { 
            var member = await _unitOfWork.Members.GetByIdAsync(id);

            if (member == null)
            {
                throw new KeyNotFoundException("Member not found");
            }

            if (status == false)
            {
                var activeMemberships = await _unitOfWork.Memberships.AnyActiveByMemberIdAsync(id);

                if (activeMemberships)
                {
                    throw new InvalidOperationException("Cannot deactivate member with active memberships");
                }
            }

            member.ChangeStatus(status);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<MemberDto> CreateMemberAsync(CreateMemberDto dto)
        {
            var existDocument = await _unitOfWork.Members.ExistDocumentNumber(dto.DocumentNumber);

            if (existDocument)
            {
                throw new InvalidOperationException("Document number already exists");
            }

            var existEmail = await _unitOfWork.Members.ExistEmail(dto.Email);

            if (existEmail)
            {
                throw new InvalidOperationException("Email already exists");
            }

            var member = _mapper.Map<Member>(dto);

            await _unitOfWork.Members.AddAsync(member);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<MemberDto>(member);
        }

        public async Task DeleteMemberAsync(int id)
        {
            var member = await _unitOfWork.Members.GetByIdAsync(id);

            if (member == null)
            {
                throw new InvalidOperationException("Member not found");
            }

            var hasActiveMemberships = await _unitOfWork.Memberships.AnyActiveByMemberIdAsync(id);

            if (!hasActiveMemberships)
            {
                throw new Exception("You cannot remove a member who has an active membership");
            }

            var hasPendingDebts = await _unitOfWork.Payments.AnyPendingByMemberIdAsync(id);

            if (!hasPendingDebts) 
            {
                throw new Exception("You cannot remove a member who has pending debts");
            }

            await _unitOfWork.Members.DeleteAsync(member);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ICollection<MemberDto>> GetActiveMembersAsync()
        {
            var members = await _unitOfWork.Members.GetAllActiveAsync();

            if (members == null)
            {
                return new List<MemberDto>();
            }

            return _mapper.Map<ICollection<MemberDto>>(members);
        }

        public async Task<ICollection<MemberDto>> GetAllMembersAsync()
        {
            var members = await _unitOfWork.Members.GetAllAsync();

            if (members == null)
            {
                return new List<MemberDto>();
            }

            return _mapper.Map<ICollection<MemberDto>>(members);
        }

        public async Task<ICollection<MemberDto>> GetInactiveMembersAsync()
        {
            var members = await _unitOfWork.Members.GetAllInactiveAsync();

            if (members == null)
            {
                return new List<MemberDto>();
            }

            return _mapper.Map<ICollection<MemberDto>>(members);
        }

        public async Task<MemberDto> GetMemberAsync(int id)
        {
            var member = await _unitOfWork.Members.GetByIdAsync(id);

            if (member == null)
            {
                throw new KeyNotFoundException("Member not found");
            }

            return _mapper.Map<MemberDto>(member);
        }

        public async Task<MemberDto> GetMemberByEmailAsync(string email)
        {
            var member = await _unitOfWork.Members.GetByEmailAsync(email);

            if (member == null) {

                throw new KeyNotFoundException("Member not found");
            }

            return _mapper.Map<MemberDto>(member);
        }

        public async Task<MemberDto> GetMemberByNameAsync(string name)
        {
            var member = await _unitOfWork.Members.GetByNameAsync(name);

            if (member == null)
            {
                throw new KeyNotFoundException("Member not found");
            }

            return _mapper.Map<MemberDto>(member);
        }

        public async Task<MemberDto> GetMemberByPhoneNumberAsync(string phoneNumber)
        {
            var member = await _unitOfWork.Members.GetByPhoneNumberAsync(phoneNumber);


            if (member == null)
            {
                throw new KeyNotFoundException("Member not found");
            }

            return _mapper.Map<MemberDto>(member);
        }

        public async Task<PagedResult<MemberDto>> GetPagedMembersAsync(PaginationParams paginationParams)
        {
            var pagedMembers = await _unitOfWork.Members.GetPagedAsync(paginationParams);

            return new PagedResult<MemberDto>
            {
                Items = _mapper.Map<IEnumerable<MemberDto>>(pagedMembers.Items),
                PageNumber = pagedMembers.PageNumber,
                PageSize = pagedMembers.PageSize,
                TotalCount = pagedMembers.TotalCount,
                TotalPages = pagedMembers.TotalPages
            };
        }

        public async Task UpdateMemberAsync(int id, UpdateMemberDto dto)
        {
            var member = await _unitOfWork.Members.GetByIdAsync(id);

            if (member == null)
            {
                throw new KeyNotFoundException("Member not found");
            }

            _mapper.Map(dto, member);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
