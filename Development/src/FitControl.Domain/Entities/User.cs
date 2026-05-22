using FitControl.Domain.Common;

namespace FitControl.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public IEnumerable<UserRole> UserRoles { get; private set; }
        public virtual Member Member { get; private set; }

        public User() { }

    }
}
