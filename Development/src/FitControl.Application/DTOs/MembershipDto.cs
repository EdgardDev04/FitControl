using FitControl.Domain.Enums;

namespace FitControl.Application.DTOs
{
    public class MembershipDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MembershipStatus Status { get; set; }
        public int MembershipPlanId { get; set; }
        public int MemberId { get; set; }
        public ICollection<PaymentDto> Payments { get; set; } = new List<PaymentDto>();
    }

    public class CreateMembershipDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MembershipStatus Status { get; set; }
        public int MembershipPlanId { get; set; }
        public int MemberId { get; set; }
        public ICollection<PaymentDto> Payments { get; set; } = new List<PaymentDto>();
    }

    public class UpdateMembershipDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MembershipStatus Status { get; set; }
        public int MembershipPlanId { get; set; }
        public int MemberId { get; set; }
        public ICollection<PaymentDto> Payments { get; set; } = new List<PaymentDto>();
    }
}
