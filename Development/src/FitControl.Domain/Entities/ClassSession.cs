using FitControl.Domain.Base;
using FitControl.Domain.Enums;

namespace FitControl.Domain.Entities
{
    public class ClassSession : BaseEntity  
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public int Capacity { get; private set; }
        public ClassSessionStatus Status { get; private set; }
        public int  ClassTypeId { get; private set; }
        public int TrainerId { get; private set; }
        public int GymId { get; private set; }
        public virtual ICollection<ClassBooking> Bookings { get; private set; } = new List<ClassBooking>();
        public virtual ClassType ClassType { get; private set; }
        public virtual Trainer Trainer { get; private set; }
        public virtual Gym Gym { get; private set; }

        public ClassSession() { }

        public ClassSession(DateTime startTime, DateTime endTime, int capacity, int classTypeId, int trainerId, int gymId)
        {
            StartTime = startTime;
            EndTime = endTime;
            Capacity = capacity;
            ClassTypeId = classTypeId;
            TrainerId = trainerId;
            GymId = gymId;
            Status = ClassSessionStatus.Scheduled;
        }

        public bool IsFull() => Bookings.Count >= Capacity;
        public bool IsUpcoming() => StartTime > DateTime.UtcNow;
        public bool IsOngoing() => StartTime <= DateTime.UtcNow && EndTime >= DateTime.UtcNow;
        public bool IsPast() => EndTime < DateTime.UtcNow;
        public bool CanBeCancelled() => Status == ClassSessionStatus.Scheduled && IsUpcoming();
        public bool HasStarted() => DateTime.Now >= StartTime;
        public int AvailableSpots() => Capacity - Bookings.Count;
        public bool CanBeCancelledByTrainer() => Status == ClassSessionStatus.Scheduled && IsUpcoming();
        public bool CanBeBooked() => Status == ClassSessionStatus.Scheduled && !IsFull() && IsUpcoming();
        public void MarkAsScheduled() => Status = ClassSessionStatus.Scheduled;
        public void MarkAsCompleted() => Status = ClassSessionStatus.Completed;
        public void MarkAsCancelled() => Status = ClassSessionStatus.Cancelled;
        
                
    }
}
