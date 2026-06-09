using FitControl.Domain.Common;
using System.Data;

namespace FitControl.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; private set; }
        public ICollection<UserRole> UserRoles { get; private set; }
        public Role() { }

        public Role(string name)
        {
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}