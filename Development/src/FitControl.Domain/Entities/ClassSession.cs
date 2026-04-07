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

        public virtual ClassType ClassType { get; private set; }
        public virtual Trainer Trainer { get; private set; }
        public virtual Gym Gym { get; private set; }
    }
}
