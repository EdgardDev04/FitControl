using FitControl.Domain.Base;

namespace FitControl.Domain.Entities
{
    public class Attendance : BaseEntity
    {
        public DateTime CheckInTime { get; private set; }
        public DateTime? CheckOutTime { get; set; }
        public int MemberId { get; private set; }
        public int GymId { get; private set; }
        public virtual Member Member { get; private set; }
        public virtual Gym Gym { get; private set; }

        public Attendance() { }

        public Attendance(int memberId, int gymId)
        {
            MemberId = memberId;
            GymId = gymId;
        }

        public void CheckIn()
        {
            CheckInTime = DateTime.UtcNow;
        }

        public void CheckOut()
        {
            CheckOutTime = DateTime.UtcNow;
        }
    }
}
