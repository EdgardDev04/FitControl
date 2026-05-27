using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Application.Interfaces.Services;

namespace FitControl.Application.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AttendanceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<IEnumerable<AttendanceDto>> GetActiveMembersNowAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<AttendanceDto>> GetAllAttendancesAsync()
        {
            var attendances = await _unitOfWork.Attendances.GetAllAsync();

            if (attendances == null) 
            {
                return new List<AttendanceDto>();
            }

            return _mapper.Map<ICollection<AttendanceDto>>(attendances);
        }

        public async Task<ICollection<AttendanceDto>> GetAttendanceByMemberIdAsync(int memberId)
        {
            var attendances = await _unitOfWork.Attendances.GetAllByMemberIdAsync(memberId);

            if (attendances == null)
            {
                return new List<AttendanceDto>();
            }

            return _mapper.Map<ICollection<AttendanceDto>>(attendances);
        }

        public async Task RegisterCheckIn(int memberId)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterCheckOut(int memberId)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<AttendanceDto>> IAttendanceService.GetActiveMembersNowAsync()
        {
            throw new NotImplementedException();
        }
    }
}
