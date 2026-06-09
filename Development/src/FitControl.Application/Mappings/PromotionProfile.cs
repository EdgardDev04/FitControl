using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Domain.Entities;

namespace FitControl.Application.Mappings
{
    public class PromotionProfile : Profile
    {
        public PromotionProfile()
        {
            CreateMap<Promotion, PromotionDto>().ReverseMap();

            CreateMap<PromotionDto, CreatePromotionDto>().ReverseMap();

            CreateMap<PromotionDto, UpdatePromotionDto>().ReverseMap();

            CreateMap<CreatePromotionDto, Promotion>().ReverseMap();

            CreateMap<UpdatePromotionDto, Promotion>().ReverseMap();
        }
    }
}
