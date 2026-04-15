using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Domain.Entities;

namespace FitControl.Application.Mappings
{
    public class MemberProfile : Profile
    {
        public MemberProfile() 
        {
            CreateMap< Member, MemberDto >().ReverseMap();

            CreateMap<CreateMemberDto, Member>();

            CreateMap< UpdateMemberDto, Member >();

        }
    }
}
