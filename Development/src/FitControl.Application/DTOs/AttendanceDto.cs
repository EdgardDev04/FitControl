namespace FitControl.Application.DTOs
{
    public class AttendanceDto
    {
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public int MemberId { get; set; }
        public int GymId { get; set; }
    }
}
