namespace FitControl.Domain.Entities
{
    public class UserRole
    {
        public int RoleId { get; private set; }
        public int UserId { get; private set; }

        public virtual User User { get; private set; }
        public virtual Role Role { get; private set; }

        public UserRole() { }

        public UserRole(int userId, int roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
