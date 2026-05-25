namespace FitControl.Application.DTOs
{
    public class PromotionDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? FixedPrice { get; set; }
        public int DurationInDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class CreatePromotionDto
    {
    }

    public class UpdatePromotionDto
    {
    }
}
