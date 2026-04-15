namespace FitControl.Application.DTOs
{
    public class InvoiceDto
    {
        public string InvoiceNumber { get;  set; } 
        public DateTime IssueDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Balance { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalAmount { get; set; }
        public int MemberId { get; set; }
        public ICollection<PaymentDto> Payments { get; set; } = new List<PaymentDto>();
    }

    public class CreateInvoiceDto
    {
        public string InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Balance { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalAmount { get; set; }
        public int MemberId { get; set; }
        public ICollection<PaymentDto> Payments { get; set; } = new List<PaymentDto>();
    }
}
