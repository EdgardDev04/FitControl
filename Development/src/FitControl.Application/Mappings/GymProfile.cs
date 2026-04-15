using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Domain.Entities;

namespace FitControl.Application.Mappings
{
    public class GymProfile : Profile
    {
        public GymProfile()
        {
            CreateMap<Gym, GymDto>().ReverseMap();

            CreateMap<CreateGymDto, Gym>();

            CreateMap<UpdateGymDto, Gym>();
        }
    }
}
