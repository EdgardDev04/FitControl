using FitControl.Domain.Common;
using FitControl.Domain.Enums;

namespace FitControl.Domain.Entities
{
    public class Promotion : BaseEntity
    {
        public string Name { get; private set; } 
        public string Description { get; private set; }
        public decimal? DiscountPercentage { get; private set; }
        public decimal? DiscountAmount { get; private set; }
        public decimal? FixedPrice { get; private set; }
        public int DurationInDays { get; private set; }
        public PromotionStatus Status { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        public bool IsActive { get; private set; }
        public ICollection<Membership?> Memberships { get; private set; }

        public Promotion() { }
    }
}
