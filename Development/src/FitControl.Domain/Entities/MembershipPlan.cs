using FitControl.Domain.Common;

namespace FitControl.Domain.Entities
{
    public class MembershipPlan : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int DurationInDays { get; private set; }
        public bool IsActive { get; private set; } = true;
        public bool IsDeleted { get; private set; } = false;

        public IEnumerable<Membership> Memberships { get; private set; }
        public MembershipPlan() { } 
    }
}
