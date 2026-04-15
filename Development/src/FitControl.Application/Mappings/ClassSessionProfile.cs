using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Domain.Entities;

namespace FitControl.Application.Mappings
{
    public class ClassSessionProfile : Profile
    {
        public ClassSessionProfile()
        {
            CreateMap<ClassSession, ClassSessionDto>().ReverseMap();

            CreateMap<CreateClassSessionDto, ClassSession>();
            
            CreateMap<UpdateClassSessionDto, ClassSession>();
        }
    }
}
