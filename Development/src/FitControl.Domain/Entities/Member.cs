using FitControl.Domain.Common;
using FitControl.Domain.Enums;
using FitControl.Domain.ValueObject;

namespace FitControl.Domain.Entities
{
    public class Member : BaseEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Email Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string EmergencyContact { get; private set; }
        public DateOnly BirthDate { get; private set; }
        public Gender Gender { get; private set; }
        public DateOnly CreatedAt { get; private set; } 
        public bool IsDeleted { get; private set; } = false;
        public bool IsActive { get; private set; }
        public int? UserId { get; private set; }
        public virtual User User { get; private set; }
        public IEnumerable<Attendance?> Attendances { get; private set; }
        public IEnumerable<Payment> Payments { get; private set; }
        public IEnumerable<Membership?> Memberships { get; private set; }

        public Member() { }
    }
}
