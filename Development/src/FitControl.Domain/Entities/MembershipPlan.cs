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
        public ICollection<Membership> Memberships { get; private set; }
        
        public MembershipPlan() { }

        public MembershipPlan(string name, string description, decimal price, int durationInDays)
        {
            Name = name;
            Description = description;
            Price = price;
            DurationInDays = durationInDays;
            IsActive = true;
        }

        public void ChangePrice(decimal price)
        {
            Price = price;
        }

        public void ChangeStatus(bool isActive)
        {
            if (IsDeleted)
            {
                throw new InvalidOperationException("Deleted membership plans cannot change status.");
            }

            IsActive = isActive;
        }
    }
}
