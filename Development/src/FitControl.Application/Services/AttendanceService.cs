using AutoMapper;
using FitControl.Domain.Entities;
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

        public async Task<ICollection<AttendanceDto>> GetAllAttendancesAsync()
        {
            var attendances = await _unitOfWork.Attendances.GetAllAsync();

            if (attendances == null) 
            {
                return new List<AttendanceDto>();
            }

            return _mapper.Map<ICollection<AttendanceDto>>(attendances);
        }

        public async Task<AttendanceDto> GetAttendanceAsync(int id)
        {
            var attendance = await _unitOfWork.Attendances.GetByIdAsync(id);

            if (attendance == null)
            {
                throw new KeyNotFoundException("Attendance not found");
            }

            return _mapper.Map<AttendanceDto>(attendance);
        }

        public async Task<ICollection<AttendanceDto>> GetAttendanceByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var attendances = await _unitOfWork.Attendances.GetAllByDateRangeAsync(startDate, endDate);

            if (attendances == null)
            {
                return new List<AttendanceDto>();
            }

            return _mapper.Map<ICollection<AttendanceDto>>(attendances);
        }

        public async Task<ICollection<AttendanceDto>> GetAttendanceByMemberIdAsync(int memberId)
        {
            var member = await _unitOfWork.Members.GetByIdAsync(memberId);

            if (member == null)
            {
                throw new KeyNotFoundException("Member not found");
            }

            var attendances = await _unitOfWork.Attendances.GetAllByMemberIdAsync(member.Id);

            if (attendances == null)
            {
                return new List<AttendanceDto>();
            }

            return _mapper.Map<ICollection<AttendanceDto>>(attendances);
        }

        public async Task<ICollection<AttendanceDto>> GetRegisterMembersTodayAsync()
        { 
            var todayStart = DateTime.Today;
            var todayEnd = DateTime.Today.AddDays(1).AddTicks(-1);

            var todayAttendances = await _unitOfWork.Attendances.GetAllByDateRangeAsync(todayStart, todayEnd);

            if (todayAttendances == null)
            {
                return new List<AttendanceDto>();
            }

            return _mapper.Map<ICollection<AttendanceDto>>(todayAttendances);
        }

        public async Task RegisterCheckInAsync(int memberId)
        { 
            var member = await _unitOfWork.Members.GetByIdAsync(memberId);

            if (member == null)
            {
                throw new KeyNotFoundException("Member not found");
            }

            member.EnsureCanCheckIn();

            var hasActiveAttendance = await _unitOfWork.Attendances.HasAnyActiveAttendanceAsync(memberId);

            if (hasActiveAttendance) 
            {
                throw new InvalidOperationException("Member already has an active attendance.");
            }

            var attendance = new Attendance(member.Id, DateTime.Now);

            await _unitOfWork.Attendances.AddAsync(attendance);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RegisterCheckOutAsync(int memberId)
        {
            var member = await _unitOfWork.Members.GetByIdAsync(memberId);

            if (member == null)
            {
                throw new KeyNotFoundException("Member not found");
            }
            var activeAttendance = await _unitOfWork.Attendances.GetActiveAttendanceAsync(memberId);
           
            if (activeAttendance == null)
            {
                throw new InvalidOperationException("The member does not have an active Check-In to be able to register an exit.");
            }

            activeAttendance.RegisterCheckOut();

            await _unitOfWork.Attendances.UpdateAsync(activeAttendance);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAttendanceAsync(int attendanceId)
        {
            var attendance = await _unitOfWork.Attendances.GetByIdAsync(attendanceId);

            if (attendance == null)
            {
                throw new KeyNotFoundException("Attendance not found");
            }

            await _unitOfWork.Attendances.DeleteAsync(attendance);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
