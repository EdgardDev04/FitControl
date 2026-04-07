using FitControl.Domain.Base;
using FitControl.Domain.Enums;

namespace FitControl.Domain.Entities
{
    public class ClassBooking : BaseEntity
    {

        public DateTime BookingDate { get; private set; }
        public BookingStatus Status { get; private set; }
        public int ClassSessionId { get; private set; }
        public int MemberId { get; private set; }
        public virtual ClassSession Session { get; private set; }
        public virtual Member Member { get; private set; }
    
    }
}
