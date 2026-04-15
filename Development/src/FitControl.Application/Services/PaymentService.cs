using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Domain.Entities;
using FitControl.Domain.Interfaces;

namespace FitControl.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync()
        {
            var payments = await _unitOfWork.Payments.GetAllAsync();

            if (payments == null)
                return new List<PaymentDto>();

            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<IEnumerable<PaymentDto>> GetInvoicePaymentsAsync(int invoiceId)
        {
            var payments = await _unitOfWork.Payments.GetByInvoiceIdAsync(invoiceId);

            if (payments == null)
                return new List<PaymentDto>();

            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<IEnumerable<PaymentDto>> GetMemberPaymentsAsync(int memberId)
        {
            var payments = await _unitOfWork.Payments.GetByMemberIdAsync(memberId);

            if (payments == null)
                return new List<PaymentDto>();

            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<PaymentDto?> GetPaymentByIdAsync(int paymentId)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(paymentId);

            if ( payment == null) 
                throw new KeyNotFoundException();

            return _mapper.Map<PaymentDto>(payment);
        }

        public async Task RegisterPaymentAsync(CreatePaymentDto dto)
        {
            var payment = _mapper.Map<Payment>(dto);

            await _unitOfWork.Payments.AddAsync(payment);

            var invoice = await _unitOfWork.Invoices.GetByIdAsync(dto.InvoiceId);

            if (invoice == null)
                throw new KeyNotFoundException();
            else
            {
                invoice.MarkAsPaid();
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
