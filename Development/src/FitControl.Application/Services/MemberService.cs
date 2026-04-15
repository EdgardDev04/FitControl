using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Domain.Entities;
using FitControl.Domain.Interfaces;

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

        public async Task RegisterMemberAsync(MemberDto memberDto)
        {
            var member = _mapper.Map<Member>(memberDto);

            await _unitOfWork.Members.AddAsync(member);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteMemberAsync(int id)
        {
            var member = await _unitOfWork.Members.GetByIdAsync(id);

            if (member == null)
            {
                throw new KeyNotFoundException();
            }

            await _unitOfWork.Members.DeleteAsync(member);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetAllMembersAsync()
        {
            var members = _unitOfWork.Members.GetAllAsync();

            if (members == null)
                return new List<MemberDto>();

            return _mapper.Map<IEnumerable<MemberDto>>(members);
        }

        public async Task<MemberDto> GetMemberByIdAsync(int id)
        {
            var member = await _unitOfWork.Members.GetByIdAsync(id);

            if( member == null)
                throw new KeyNotFoundException();

            return _mapper.Map<MemberDto>(member);
        }

        public async Task MarkMemberAsActiveAsync(int id)
        {
            var member = await _unitOfWork.Members.GetByIdAsync(id);

            if (member == null)
            {
                throw new KeyNotFoundException();
            }
            member.MarkAsActivate();
            
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task MarkMemberAsInactiveAsync(int id)
        {
            var member = await _unitOfWork.Members.GetByIdAsync(id);

            if (member == null)
            {
                throw new InvalidOperationException();
            }
            member.MarkAsInactivate();

            await _unitOfWork.SaveChangesAsync();
        }

        public Task<IEnumerable<MemberDto>> SearchMembersAsync(string query)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateMemberAsync(int id, MemberDto memberDto)
        {
            var member = await _unitOfWork.Members.GetByIdAsync(id);

            if ( member == null)
                throw new KeyNotFoundException();

            _mapper.Map(memberDto, member);
            
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetAllActivateMembersAsync()
        {
            var member = await _unitOfWork.Members.GetAllActiveAsync();

            if (member == null)
                return new List<MemberDto>();

            return _mapper.Map<IEnumerable<MemberDto>>(member);
        }

        public async Task<IEnumerable<MemberDto>> GetAllInactiveMembersAsync()
        {
            var member = await _unitOfWork.Members.GetAllInactiveAsync();

            if (member == null)
                return new List<MemberDto>();

            return _mapper.Map<IEnumerable<MemberDto>>(member);
        }
    }
}
