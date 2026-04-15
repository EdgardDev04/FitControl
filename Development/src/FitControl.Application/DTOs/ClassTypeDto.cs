namespace FitControl.Application.DTOs
{
    public class ClassTypeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxCapacity { get; set; }
        public int DurationMinutes { get; set; }
        public ICollection<ClassSessionDto> Sessions { get; set; } = new List<ClassSessionDto>();
    }

    public class CreateClassTypeDto
    {
    }

    public class UpdateClassTypeDto
    {
    }
}
