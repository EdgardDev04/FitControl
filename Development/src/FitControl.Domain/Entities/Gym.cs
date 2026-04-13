using FitControl.Domain.Base;
using FitControl.Domain.ValueObjects;

namespace FitControl.Domain.Entities
{
    public class Gym : BaseEntity
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public string Phone { get; private set; }
        public Email Email { get; private set; }
        public virtual ICollection<ClassSession> ClassSessions { get; private set; } = new List<ClassSession>();
        public virtual ICollection<Attendance> Attendances { get; private set; } = new List<Attendance>();
        public virtual ICollection<Member> Members { get; private set; } = new List<Member>();
        public virtual ICollection<ClassBooking> Bookings { get; private set; } = new List<ClassBooking>();
        public virtual ICollection<Trainer> Trainers { get; private set; } = new List<Trainer>();
    }
}
