using FitControl.Domain.Enums;

namespace FitControl.Application.DTOs
{
    public class ClassBookingDto
    {
        public DateTime BookingDate { get; set; }
        public BookingStatus Status { get; set; }
        public int ClassSessionId { get; set; }
        public int MemberId { get; set; }
    }
}
