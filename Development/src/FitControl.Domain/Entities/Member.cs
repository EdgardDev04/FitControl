using FitControl.Domain.Base;
using FitControl.Domain.Enums;
using FitControl.Domain.ValueObjects;

namespace FitControl.Domain.Entities
{
    public class Member : BaseEntity
    {
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public DocumentType DocumentType { get; private set; }
        public string DocumentNumber { get; private set; } = string.Empty;  
        public Email Email { get; private set; }
        public string? Phone { get; private set; }
        public DateTime DateOfBirth {  get; private set; }
        public DateTime JoinDate { get; private set; }
        public bool IsActive { get; private set; }
        public int GymId { get; private set; }
        public virtual Gym Gym { get; private set; }
        public virtual ICollection<Membership> Memberships { get; set; } = new List<Membership>();
        public virtual ICollection<ClassBooking> ClassBookings { get; set; } = new List<ClassBooking>();
        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        
    }
}
