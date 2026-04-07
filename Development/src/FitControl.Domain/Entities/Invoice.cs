using FitControl.Domain.Base;

namespace FitControl.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public string InvoiceNumber { get; private set; } = string.Empty;
        public DateTime IssueDate { get; private set; }
        public decimal SubTotal { get; private set; }
        public decimal Balance { get; private set; }
        public decimal Discount { get; private set; }
        public decimal Tax { get; private set; }
        public decimal TotalAmount { get; private set; }
        public int MemberId { get; private set; }
        public virtual  Member Member { get; private set; }
    }
}
