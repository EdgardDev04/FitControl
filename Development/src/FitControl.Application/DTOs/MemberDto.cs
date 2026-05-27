namespace FitControl.Application.DTOs
{
    public record MemberDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string EmergencyContact { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; }
        public int? UserId { get; set; }
        public ICollection<AttendanceDto?> Attendances { get; set; }
        public ICollection<PaymentDto> Payments { get; set; }
        public ICollection<MembershipDto?> Memberships { get; set; }
    }

    public record CreateMemberDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string EmergencyContact { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }

    public record UpdateMemberDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string EmergencyContact { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }
}
