namespace FitControl.Application.DTOs
{
    public class MembershipPlanDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<MembershipDto> Memberships { get; set; } = new List<MembershipDto>();
    }

    public class CreateMembershipPlanDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateMembershipPlanDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }
        public bool IsActive { get; set; }
    }
}
