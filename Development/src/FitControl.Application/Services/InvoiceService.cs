using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Domain.Entities;
using FitControl.Domain.Interfaces;

namespace FitControl.Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CancelInvoiceAsync(int invoiceId)
        {
            var invoice = await _unitOfWork.Invoices.GetByIdAsync(invoiceId);

            if (invoice == null)
                throw new KeyNotFoundException($"Invoice with ID {invoiceId} not found.");

            invoice.MarkAsCancelled();

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task CreateInvoiceAsync(CreateInvoiceDto dto)
        {
            var invoice = _mapper.Map<Invoice>(dto);
            
            await _unitOfWork.Invoices.AddAsync(invoice);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync()
        {
            var invoices = await _unitOfWork.Invoices.GetAllAsync();

            if (invoices == null)
                return new List<InvoiceDto>();

            return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
        }

        public async Task<InvoiceDto?> GetInvoiceByIdAsync(int invoiceId)
        {
            var invoice = await _unitOfWork.Invoices.GetByIdAsync(invoiceId);

            if (invoice == null)
                return null;

            return _mapper.Map<InvoiceDto>(invoice);
        }

        public async Task<IEnumerable<InvoiceDto>> GetMemberInvoicesAsync(int memberId)
        {
            var invoices = await _unitOfWork.Invoices.GetByMemberIdAsync(memberId);

            if (invoices == null)
                return new List<InvoiceDto>();

            return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
        }

        public async Task MarkInvoiceAsPaidAsync(int invoiceId)
        {
            var invoice = await _unitOfWork.Invoices.GetByIdAsync(invoiceId);

            if (invoice == null) 
                throw new KeyNotFoundException($"Invoice with ID {invoiceId} not found.");

            invoice.MarkAsPaid();

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
