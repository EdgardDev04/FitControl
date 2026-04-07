using FitControl.Domain.Base;
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
        public bool IsActive { get; private set; }
        public virtual ICollection<ClassSession> Sessions { get; private set; } = new List<ClassSession>();
    }
}
