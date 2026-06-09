namespace FitControl.Application.DTOs
{
    public record PaymentDto
    {
        public int Id { get; set; }
        public decimal Amount { get; private set; }
        public string Method { get; private set; }
        public string Status { get; set; }
        public DateTime PaidAt { get; private set; }
        public int MemberId { get; private set; }
        public int MembershipId { get; private set; }
    }

    public record PaymentResponseDto
    { 
    
    }

    public record ProcessPaymentDto
    {

    }
     
    public record RefundResponseDto
    {

    }

    public record RefundRequestDto
    {

    }

    public record CancelMembershipDto
    {

    }

    public record RenewMembershipDto
    {

    }
}
