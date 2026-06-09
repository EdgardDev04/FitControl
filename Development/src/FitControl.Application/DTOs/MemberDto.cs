using FitControl.Domain.Enums;

namespace FitControl.Application.DTOs
{
    public record MemberDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public DocumentType DocumentType { get; set; } 
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string EmergencyContact { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public record CreateMemberDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public DocumentType DocumentType { get; set; } 
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? EmergencyContact { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public record UpdateMemberDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public DocumentType DocumentType { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string EmergencyContact { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public bool IsActive { get; set; } 

    }
}
