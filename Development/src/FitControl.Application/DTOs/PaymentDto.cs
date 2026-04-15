using FitControl.Domain.Enums;

namespace FitControl.Application.DTOs
{
    public class PaymentDto
    {
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod Method { get; set; }
        public string TransactionReference { get; set; }
        public int MembershipId { get; set; }
        public int InvoiceId { get; set; }
    }

    public class CreatePaymentDto
    {
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public PaymentMethod Method { get; set; }
        public string TransactionReference { get; set; }
        public int MembershipId { get; set; }
        public int InvoiceId { get; set; }
    }
}
