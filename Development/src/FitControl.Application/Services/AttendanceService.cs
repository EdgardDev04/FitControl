using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Domain.Entities;
using FitControl.Domain.Interfaces;

namespace FitControl.Application.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMembershipService _membershipService;

        public AttendanceService(IUnitOfWork unitOfWork, IMapper mapper, IMembershipService membershipService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _membershipService = membershipService;
        }

        public async Task CheckInAsync(int memberId)
        {
            var isActive = await _membershipService.HasActiveMembershipAsync(memberId);

            if (!isActive) 
                throw new InvalidOperationException("Member does not have an active membership.");

            var attendance = new Attendance(memberId);
                        
            await _unitOfWork.Attendances.AddAsync(attendance);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task CheckOutAsync(int attendanceId)
        {
            var attendance = await _unitOfWork.Attendances.GetByIdAsync(attendanceId);

            if (attendance == null)
                throw new KeyNotFoundException();

            attendance.CheckOut();

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<AttendanceDto>> GetAttendancesByDateAsync(DateTime date)
        {
            var attendances = await _unitOfWork.Attendances.GetAttendancesByDateAsync(date);

            if (attendances == null)
                return new List<AttendanceDto>();

            return _mapper.Map<IEnumerable<AttendanceDto>>(attendances);
        }

        public async Task<IEnumerable<AttendanceDto>> GetMemberAttendancesAsync(int memberId)
        {
            var attendances = await _unitOfWork.Attendances.GetAttendancesByMemberIdAsync(memberId);

            if (attendances == null)
                return new List<AttendanceDto>();

            return _mapper.Map<IEnumerable<AttendanceDto>>(attendances);
        }

        public async Task<bool> IsMemberInsideGymAsync(int memberId)
        {
            var attendance = await _unitOfWork.Attendances.GetByIdAsync(memberId);

            if (attendance == null)
                throw new KeyNotFoundException();

            if ( attendance.GetCheckInTime == null)
                return false;

            return true;
        }
    }
}
