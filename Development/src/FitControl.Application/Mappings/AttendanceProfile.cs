using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Domain.Entities;

namespace FitControl.Application.Mappings
{
    public class AttendanceProfile : Profile
    {
        public AttendanceProfile() 
        {
            CreateMap< Attendance, AttendanceDto >().ReverseMap();
        }
    }
}
