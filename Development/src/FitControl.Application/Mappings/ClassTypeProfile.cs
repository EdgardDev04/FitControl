using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Domain.Entities;

namespace FitControl.Application.Mappings
{
    public class ClassTypeProfile : Profile
    {
        public ClassTypeProfile()
        {
            CreateMap<ClassType, ClassTypeDto>().ReverseMap();

            CreateMap<CreateClassTypeDto, ClassType>();
    
            CreateMap<UpdateClassTypeDto, ClassType>();
        }
    }
}
