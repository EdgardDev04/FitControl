using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Domain.Entities;

namespace FitControl.Application.Mappings
{
    public class InvoiceProfile : Profile 
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice, InvoiceDto>().ReverseMap();

            CreateMap<CreateInvoiceDto, Invoice>();
        }
    }
}
