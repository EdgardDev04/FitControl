namespace FitControl.Application.DTOs
{
    public class PaymentDto
    {
        public decimal Amount { get; private set; }
        public string Method { get; private set; }
        public string Status { get; set; }
        public DateTime PaidAt { get; private set; }
        public int MemberId { get; private set; }
        public int MembershipId { get; private set; }
    }
}
