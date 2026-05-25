using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Application.Interfaces.Services;

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

        public async Task<ICollection<PaymentDto>> GetPaymentsByMemberIdAsync(int memberId)
        {
            var payments = await _unitOfWork.Payments.GetbyMemberIdAsync(memberId);

            if (payments == null)
            {
                return new List<PaymentDto>();
            }

            return _mapper.Map<ICollection<PaymentDto>>(payments);
        }

        public async Task ProcessPaymentAsync(int memberId, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
