  namespace FitControl.Application.DTOs
{
    public record AttendanceDto
    {
        public int Id { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public int MemberId { get; set; }
    }
}
