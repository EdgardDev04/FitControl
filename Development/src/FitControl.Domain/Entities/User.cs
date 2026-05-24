using FitControl.Domain.Common;
using FitControl.Domain.ValueObject;

namespace FitControl.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public Email Email { get; private set; }
        public bool IsActive { get; private set; } = true;
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? LastLoginAt { get; private set; }
        public ICollection<UserRole> UserRoles { get; private set; }
        public virtual Member Member { get; private set; }

        public User() { }

    }
}
