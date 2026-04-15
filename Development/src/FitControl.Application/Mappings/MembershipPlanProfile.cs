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

            CreateMap<CreateMembershipPlanDto, MembershipPlan>();

            CreateMap<UpdateMembershipPlanDto, MembershipPlan>();
        }
    }
}
