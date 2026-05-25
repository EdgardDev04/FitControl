using AutoMapper;
using FitControl.Domain.Entities;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Application.Interfaces.Services;

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

        public async Task CreateMemberAsync(CreateMemberDto dto)
        {
            var member = _mapper.Map<Member>(dto);

            await _unitOfWork.Members.AddAsync(member);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteMemberAsync(int id)
        {
            var member = await _unitOfWork.Members.GetByIdAsync(id);

            if (member == null)
            {
                throw new InvalidOperationException("Member not found");
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

        public async Task<MemberDto> GetMemberByEmailAsync(string email)
        {
            var member = await _unitOfWork.Members.GetByEmailAsync(email);

            if (member == null) {
                return null;
            }

            return _mapper.Map<MemberDto>(member);
        }

        public async Task<MemberDto> GetMemberByIdAsync(int id)
        {
            var member = await _unitOfWork.Members.GetByIdAsync(id);

            if (member == null)
            {
                return null;
            }

            return _mapper.Map<MemberDto>(member);
        }

        public async Task<MemberDto> GetMemberByNameAsync(string name)
        {
            var member = await _unitOfWork.Members.GetByNameAsync(name);

            if (member == null)
            {
                return null;
            }

            return _mapper.Map<MemberDto>(member);
        }

        public async Task UpdateMemberAsync(int id, UpdateMemberDto dto)
        {
            var member = await _unitOfWork.Members.GetByIdAsync(id);

            if (member == null)
            {
                return;
            }

            _mapper.Map(dto, member);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
