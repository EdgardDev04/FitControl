using FitControl.Domain.Common;

namespace FitControl.Domain.Entities
{
    public class Attendance : BaseEntity
    {
        public DateTime CheckInTime { get; private set; }
        public DateTime? CheckOutTime { get; private set; }
        public int MemberId { get; private set; }
        public virtual Member Member { get; private set; }

        protected Attendance() { }

        public Attendance(int memberId, DateTime checkInTime)
        {
            MemberId = memberId;
            CheckInTime = checkInTime;
        }

        public void RegisterCheckIn()
        {
            CheckInTime = DateTime.Now;
        }

        public void RegisterCheckOut()
        {
            if (CheckOutTime < CheckInTime)
            {
                throw new InvalidOperationException("Check-out time cannot be before check-in time.");
            }

            CheckOutTime = DateTime.Now;
        }
    }
}
