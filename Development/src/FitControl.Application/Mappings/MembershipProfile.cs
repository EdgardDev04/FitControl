using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Domain.Entities;

namespace FitControl.Application.Mappings
{
    public class MembershipProfile : Profile
    {
        public MembershipProfile() 
        {
            CreateMap<Membership, MembershipDto>().ReverseMap();

            CreateMap<MembershipDto, CreateMembershipDto>().ReverseMap();

            CreateMap<MembershipDto, UpdateMembershipDto>().ReverseMap();
        }
    }
}
