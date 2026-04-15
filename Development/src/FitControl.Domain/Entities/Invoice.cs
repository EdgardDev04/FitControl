using FitControl.Domain.Base;
using FitControl.Domain.Enums;

namespace FitControl.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public string InvoiceNumber { get; private set; } = string.Empty;
        public InvoiceStatus Status { get; private set; } = InvoiceStatus.Pending;
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


        public decimal CalculateTotalAmount() => SubTotal - Discount + Tax;
        
        public decimal CalculateBalance() => TotalAmount - (TotalAmount - Balance);
        
        public decimal CalculateDiscount(decimal discount) => TotalAmount * discount / 100;
        
        public void MarkAsPaid()
        {
            Status = InvoiceStatus.Paid;
            Balance = 0;
        }

        public void MarkAsPending() => Status = InvoiceStatus.Pending;
        public void MarkAsPartiallyPaid() => Status = InvoiceStatus.PartiallyPaid;
        public void MarkAsOverdue() => Status = InvoiceStatus.Overdue;
        public void MarkAsCancelled() => Status = InvoiceStatus.Cancelled;
    }
}
