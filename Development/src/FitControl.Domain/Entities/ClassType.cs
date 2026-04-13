using FitControl.Domain.Base;

namespace FitControl.Domain.Entities
{
    public class ClassType : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int MaxCapacity { get; private set; }
        public int DurationMinutes { get; private set; }
        public virtual ICollection<ClassSession> Sessions { get; private set; } = new List<ClassSession>();

        public ClassType() { }

        public ClassType(string name, string description, int maxCapacity, int durationMinutes)
        {
            Name = name;
            Description = description;
            MaxCapacity = maxCapacity;
            DurationMinutes = durationMinutes;
        }


    }
}
