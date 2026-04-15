using FitControl.Domain.Enums;

namespace FitControl.Application.DTOs
{
    public class ClassSessionDto
    {
        public DateTime StartTime { get;  set; }
        public DateTime EndTime { get; set; }
        public int Capacity { get; set; }
        public ClassSessionStatus Status { get; set; }
        public int ClassTypeId { get; set; }
        public int TrainerId { get; set; }
        public int GymId { get; set; }
        public ICollection<ClassBookingDto> Bookings { get; set; } = new List<ClassBookingDto>();
    }

    public class CreateClassSessionDto
    {
    }

    public class UpdateClassSessionDto
    {
    }
}
