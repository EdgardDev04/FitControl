using FitControl.Domain.Common;

namespace FitControl.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; private set; }
        public ICollection<UserRole> UserRoles { get; private set; }
        public Role() { }
    }
}
