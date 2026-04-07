using FitControl.Domain.Base;
using FitControl.Domain.Enums;

namespace FitControl.Domain.Entities
{
    public class Payment : BaseEntity
    {

        public DateTime PaymentDate { get; private set; }
        public decimal Amount { get; private set; }
        public PaymentMethod Method { get; private set; }
        public string TransactionReference { get; private set; }
        public int InvoiceId { get; private set; }
        public virtual Invoice Invoice { get; private set; }
    }
}
