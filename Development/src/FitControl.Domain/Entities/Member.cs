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
        public virtual ICollection<Invoice> Invoices { get; private set; } = new List<Invoice>();
        public virtual ICollection<ClassBooking> Bookings { get; private set; } = new List<ClassBooking>();
        public virtual ICollection<Membership> Memberships { get; private set; } = new List<Membership>();
        public virtual ICollection<Attendance> Attendances { get; private set; } = new List<Attendance>();


        public Member() { }

        public int CalculateAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }

        public void MarkAsActivate() => IsActive = true;

        public void MarkAsInactivate() => IsActive = false;

        public void UpdateDocumentNumber(string newDocumentNumber)
        {
            DocumentNumber = newDocumentNumber;
        }

        public string GetDocumentNumber() => DocumentNumber;

        public string GetFullName() => $"{FirstName} {LastName}".Trim();

        public void UpdatePhone(string? newPhone)
        {
            Phone = newPhone;
        }

        public void UpdateEmail(Email newEmail)
        {
            Email = newEmail;
        }
    }
}
