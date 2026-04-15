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

        public Attendance(int memberId)
        {
            CheckInTime = DateTime.Today;
            MemberId = memberId;
        }

        public Attendance(int memberId, int gymId)
        {
            MemberId = memberId;
            GymId = gymId;
        }
        
        public Attendance(int memberId, int gymId, DateTime checkInTime)
        {
            MemberId = memberId;
            GymId = gymId;
            CheckInTime = checkInTime;
        }

        public decimal CalculateFee(decimal hourlyRate)
        {
            if (CheckOutTime == null)
                return 0;
            var durationInHours = (CheckOutTime.Value - CheckInTime).TotalHours;
            return (decimal)durationInHours * hourlyRate;
        }

        public int GetDurationInMinutes()
        {
            if (CheckOutTime == null)
                return 0;
            return (int)(CheckOutTime.Value - CheckInTime).TotalMinutes;
        }

        public void CheckIn()
        {
            CheckInTime = DateTime.UtcNow;
        }

        public void CheckOut()
        {
            CheckOutTime = DateTime.UtcNow;
        }

        public DateTime GetCheckInTime() => CheckInTime;

        public DateTime? GetCheckOutTime() => CheckOutTime;
    }
}
