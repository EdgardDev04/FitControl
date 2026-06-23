using FitControl.Application.Common;
using FitControl.Application.Interfaces.Services;
using FitControl.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitControl.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPayments([FromQuery] PaginationParams paginationParams)
        {
            var result = await _paymentService.GetPagedPaymentsAsync(paginationParams);

            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();

            return Ok(payments);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPayment([FromRoute] int id)
        {
            var payment = await _paymentService.GetPaymentAsync(id);

            return Ok(payment);
        }

        [HttpGet("member/{memberId:int}")]
        public async Task<IActionResult> GetPaymentsByMemberId([FromRoute] int memberId)
        {
            var payments = await _paymentService.GetPaymentsByMemberIdAsync(memberId);

            return Ok(payments);
        }
    }
}
