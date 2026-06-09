using FitControl.Domain.Enums;

namespace FitControl.Application.DTOs
{
    public record MembershipDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public bool IsAutoRenew { get; set; }
    }

    public record CreateMembershipDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MembershipStatus Status { get; set; } = MembershipStatus.Active;
        public bool IsAutoRenew { get; set; } = false;
        public int MemberId { get; set; }
        public int MembershipPlanId { get; set; }
    }

    public record UpdateMembershipDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MembershipStatus Status { get; set; } = MembershipStatus.Active;
        public bool IsAutoRenew { get; set; }
    }
}
