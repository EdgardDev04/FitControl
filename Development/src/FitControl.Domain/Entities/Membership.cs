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

        public Membership() { }

        public Membership(int memberId, int planId, DateTime startDate, DateTime endDate)
        {
            MemberId = memberId;
            MembershipPlanId = planId;
            StartDate = startDate;
            EndDate = endDate;
            Status = MembershipStatus.Active;
        }



        public MembershipStatus GetStatus() => Status;  

        public void MarkAsActive() => Status = MembershipStatus.Active;
        public void MarkAsInactive() => Status = MembershipStatus.Inactive;
        public void MarkAsExpired() => Status = MembershipStatus.Expired;
        public void MarkAsCancelled() => Status = MembershipStatus.Cancelled;
        public void MarkAsSuspended() => Status = MembershipStatus.Suspended;
        public void MarkAsPendingPayment() => Status = MembershipStatus.PendingPayment;

        public void UpdateStartDate(DateTime newStartDate) => StartDate = newStartDate;

        public void ExtendMembership(int additionalDays)
        {
            EndDate = EndDate.AddDays(additionalDays);
            if (Status == MembershipStatus.Expired)
                Status = MembershipStatus.Active;
        }
    }
}
