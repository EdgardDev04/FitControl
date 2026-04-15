using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Domain.Entities;

namespace FitControl.Application.Mappings
{
    public class ClassBookingProfile : Profile
    {
        public ClassBookingProfile()
        {
            CreateMap<ClassBooking, ClassBookingDto>().ReverseMap();
        }
    }
}
