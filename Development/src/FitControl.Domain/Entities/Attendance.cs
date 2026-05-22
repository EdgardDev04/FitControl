using FitControl.Domain.Common;

namespace FitControl.Domain.Entities
{
    public class Attendance : BaseEntity
    {
        public DateTime? CheckInTime { get; private set; }
        public DateTime CheckOutTime { get; private set; }
        public int MemberId { get; private set; }
        public virtual Member Member { get; private set; }

        public Attendance() { }
    }
}
