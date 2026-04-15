using FitControl.Domain.Enums;
using FitControl.Domain.ValueObjects;

namespace FitControl.Application.DTOs
{
    public class TrainerDto
    {
        public string Name { get; set; } 
        public string LastName { get; set; } 
        public Email Email { get; set; }
        public string Phone { get; set; }
        public string Specialty { get; set; }
        public DateTime HireDate { get; set; }
        public string Bio { get; set; }
        public TrainerStatus Status { get; set; }
        public int GymId { get; set; }
        public virtual ICollection<ClassSessionDto> Sessions { get; set; } = new List<ClassSessionDto>();
    }

    public class CreateTrainerDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Email Email { get; set; }
        public string Phone { get; set; }
        public string Specialty { get; set; }
        public DateTime HireDate { get; set; }
        public string Bio { get; set; }
        public TrainerStatus Status { get; set; }
        public int GymId { get; set; }
        public virtual ICollection<ClassSessionDto> Sessions { get; set; } = new List<ClassSessionDto>();
    }

    public class UpdateTrainerDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Email Email { get; set; }
        public string Phone { get; set; }
        public string Specialty { get; set; }
        public DateTime HireDate { get; set; }
        public string Bio { get; set; }
        public TrainerStatus Status { get; set; }
        public int GymId { get; set; }
        public virtual ICollection<ClassSessionDto> Sessions { get; set; } = new List<ClassSessionDto>();
    }
}
