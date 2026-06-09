using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Application.Interfaces.Services;
using FitControl.Domain.Entities;

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

        public async Task<ICollection<PaymentDto>> GetAllPaymentsAsync()
        {
            var payments = await _unitOfWork.Payments.GetAllAsync();

            if (payments == null)
            {
                return new List<PaymentDto>();
            }

            return _mapper.Map<ICollection<PaymentDto>>(payments);
        }

        public async Task<PaymentDto> GetPaymentAsync(int id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);

            if (payment == null)
            {
                throw new KeyNotFoundException($"Payment not found.");
            }

            return _mapper.Map<PaymentDto>(payment);
        }

        public async Task<ICollection<PaymentDto>> GetPaymentsByMemberIdAsync(int memberId)
        {
            var payments = await _unitOfWork.Payments.GetbyMemberIdAsync(memberId);

            if (payments == null)
            {
                return new List<PaymentDto>();
            }

            return _mapper.Map<ICollection<PaymentDto>>(payments);
        }

        public Task<PaymentResponseDto> ProcessPaymentAsync(ProcessPaymentDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<RefundResponseDto> RefundPaymentAsync(int paymentId, RefundRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
