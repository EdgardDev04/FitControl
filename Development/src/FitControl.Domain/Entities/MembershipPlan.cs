using FitControl.Domain.Base;

namespace FitControl.Domain.Entities
{
    public class MembershipPlan : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public int DurationInDays { get; private set; }
        public bool IsActive { get; private set; }
        public virtual ICollection<Membership> Memberships { get; private set; } = new List<Membership>();
    }
}
