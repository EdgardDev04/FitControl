using FitControl.Domain.Common;
using FitControl.Domain.Enums;

namespace FitControl.Domain.Entities
{
    public class Membership : BaseEntity
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public MembershipStatus Status { get; private set; }
        public bool IsDeleted { get; private set; }
        public bool IsAutoRenew { get; private set; }
        public int MemberId { get; private set; }
        public int MembershipPlanId { get; private set; }
        public int? PromotionId { get; private set; }
        public ICollection<Payment> Payments { get; private set; }
        public virtual Member Member { get; private set; }
        public virtual MembershipPlan MembershipPlan { get; private set; }
        public virtual Promotion Promotion { get; private set; }

        public Membership() { }
    }
}
