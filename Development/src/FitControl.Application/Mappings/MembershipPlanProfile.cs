using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Domain.Entities;

namespace FitControl.Application.Mappings
{
    public class MembershipPlanProfile : Profile
    {
        public MembershipPlanProfile() 
        {
            CreateMap<MembershipPlan, MembershipPlanDto>().ReverseMap();

            CreateMap<MembershipPlanDto, CreateMembershipPlanDto>().ReverseMap();

            CreateMap<MembershipPlanDto, UpdateMembershipPlanDto>().ReverseMap();

            CreateMap<CreateMembershipPlanDto, MembershipPlan>().ReverseMap();

            CreateMap<UpdateMembershipPlanDto, MembershipPlan>().ReverseMap();

        }
    }
}
