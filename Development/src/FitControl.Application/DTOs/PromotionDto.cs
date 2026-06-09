using AutoMapper.Configuration.Conventions;
using FitControl.Domain.Enums;

namespace FitControl.Application.DTOs
{
    public record PromotionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? FixedPrice { get; set; }
        public int DurationInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }

    public record CreatePromotionDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? FixedPrice { get; set; }
        public int DurationInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PromotionStatus Status { get; set; } = PromotionStatus.Active;
    }

    public record UpdatePromotionDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? FixedPrice { get; set; }
        public int DurationInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PromotionStatus Status { get; set; } 
    }

    public record PromotionValidationResultDto
    {

    }
}
