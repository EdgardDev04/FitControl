using FitControl.Domain.Enums;

namespace FitControl.Application.DTOs
{
    public class MembershipDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public bool IsAutoRenew { get; set; }
        public int MemberId { get; set; }
        public int MembershipPlanId { get; set; }
        public int? PromotionId { get; set; }

        public class CreateMembershipDto
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Status { get; set; }
            public bool IsAutoRenew { get; set; }
        }

        public class UpdateMembershipDto
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Status { get; set; }
            public bool IsAutoRenew { get; set; }
        }
    }
}
