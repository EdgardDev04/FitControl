using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Domain.Entities;

namespace FitControl.Application.Mappings
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile() 
        { 
            CreateMap<Payment, PaymentDto>().ReverseMap();

            CreateMap<PaymentResponseDto, ProcessPaymentDto>().ReverseMap();

            CreateMap<RefundResponseDto, RefundRequestDto>().ReverseMap();
        }
    }
}
