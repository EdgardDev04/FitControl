using FitControl.Domain.Common;
using FitControl.Domain.Enums;

namespace FitControl.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public decimal Amount { get; private set; }
        public PaymentMethod Method { get; private set; }
        public PaymentStatus Status { get; set; }
        public DateTime PaidAt { get; private set; }
        public int MemberId { get; private set; }
        public int MembershipId { get; private set; }
        public virtual Member Member { get; private set; }
        public virtual Membership Membership { get; private set; }
        public Payment() { }

        public Payment(decimal amount, PaymentMethod method, int memberId, int membershipId)
        {
            Amount = amount;
            Method = method;
            MemberId = memberId;
            MembershipId = membershipId;
            PaidAt = DateTime.Now;
            Status = PaymentStatus.Pending;
        }


    }
}
