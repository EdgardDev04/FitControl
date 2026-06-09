using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Domain.Entities;
using FitControl.Domain.ValueObject;

namespace FitControl.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value));

            CreateMap<User, CreateUserDto>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value));

            CreateMap<User, UpdateUserDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value));

            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => Email.Create(src.Email)));

            CreateMap<UpdateUserDto, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => Email.Create(src.Email)));

            CreateMap<UserDto, CreateUserDto>().ReverseMap();
            
            CreateMap<UserDto, UpdateUserDto>().ReverseMap();
        }
    }
}
