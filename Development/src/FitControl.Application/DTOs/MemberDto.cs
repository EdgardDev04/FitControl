using FitControl.Domain.Enums;
using FitControl.Domain.ValueObjects;

namespace FitControl.Application.DTOs
{
    public class MemberDto 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public DocumentType DocumentType { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public Email Email { get; set; }
        public string? Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoinDate { get; set; }
        public bool IsActive { get; set; }
        public int GymId { get; set; }
    }

    public class CreateMemberDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public DocumentType DocumentType { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public Email Email { get; set; }
        public string? Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GymId { get; set; }
    }

    public class UpdateMemberDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public DocumentType DocumentType { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public Email Email { get; set; }
        public string? Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
    }
}
