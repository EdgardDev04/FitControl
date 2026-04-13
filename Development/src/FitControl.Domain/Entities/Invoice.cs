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
        public virtual ICollection<Payment> Payments { get; private set; } = new List<Payment>();

        public virtual ICollection<InvoiceItem> InvoiceItems { get; private set; } = new List<InvoiceItem>();


        public Invoice() { }

        public Invoice(string invoiceNumber, DateTime issueDate, decimal subTotal, decimal balance, decimal discount, decimal tax, decimal totalAmount, int memberId)
        {
            InvoiceNumber = invoiceNumber;
            IssueDate = issueDate;
            SubTotal = subTotal;
            Balance = balance;
            Discount = discount;
            Tax = tax;
            TotalAmount = totalAmount;
            MemberId = memberId;
        }


        public decimal CalculateTotalAmount()
        {
            return SubTotal - Discount + Tax;
        }

        public decimal CalculateBalance()
        {
            return TotalAmount - (TotalAmount - Balance);
        }

        public decimal CalculateDiscount(decimal discount)
        {
            return TotalAmount * discount / 100;
        } 
    }
}
