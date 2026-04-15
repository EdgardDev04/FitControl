using FitControl.Domain.Base;
using FitControl.Domain.Enums;
using FitControl.Domain.ValueObjects;

namespace FitControl.Domain.Entities
{
    public class Trainer : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public Email Email { get; private set; }
        public string Phone { get; private set; } = string.Empty;
        public string Specialty { get; private set; } = string.Empty;
        public DateTime HireDate { get; private set; }
        public string Bio { get; private set; } = string.Empty;
        public TrainerStatus Status { get; private set; }
        public int GymId { get; private set; }
        public virtual Gym Gym { get; private set; }
        public virtual ICollection<ClassSession> Sessions { get; private set; } = new List<ClassSession>();

        public Trainer() { }

        public Trainer(string name, string lastName, Email email, string phone, string specialty, DateTime hireDate, string bio)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Specialty = specialty;
            HireDate = hireDate;
            Bio = bio;
            Status = TrainerStatus.Active;
        }

        public void UpdateEmail(Email email) => Email = email;

        public void UpdatePhone(string phone) => Phone = phone;

        public TrainerStatus GetStatus() => Status;

        public void MarkAsActive() => Status = TrainerStatus.Active;
        public void MarkAsInactive() => Status = TrainerStatus.Inactive;
        public void MarkAsSuspended() => Status = TrainerStatus.Suspended;
        public void MarkAsLicensed() => Status = TrainerStatus.Licensed;
    }
}
