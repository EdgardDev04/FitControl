using FitControl.Domain.Base;

namespace FitControl.Domain.Entities
{
    public class ClassType : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int MaxCapacity { get; private set; }
        public int DurationMinutes { get; private set; }
        public ClassSession Sessions { get; private set; }
    }
}
