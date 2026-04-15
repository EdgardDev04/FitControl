using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Domain.Entities;

namespace FitControl.Application.Mappings
{
    public class TrainerProfile : Profile
    {
        public TrainerProfile() 
        {
            CreateMap<Trainer, TrainerDto>();         
            
            CreateMap<CreateTrainerDto, TrainerDto>();

            CreateMap<UpdateTrainerDto, TrainerDto>();
        }
    }
}
