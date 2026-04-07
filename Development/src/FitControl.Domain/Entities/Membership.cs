using FitControl.Domain.Base;
using FitControl.Domain.Enums;

namespace FitControl.Domain.Entities
{
    public class Membership : BaseEntity
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; } 
        public MembershipStatus Status { get; private set; }

        public int MembershipPlanId { get; private set; }
        public virtual MembershipPlan Plan { get; private set; }
        public int MemberId { get; private set; }
        public virtual Member Member { get; private set; }
        public virtual ICollection<Payment> Payments { get; private set; } = new List<Payment>();
    }
}
