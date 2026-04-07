using FitControl.Domain.Base;

namespace FitControl.Domain.Entities
{
    public class InvoiceItem : BaseEntity
    {
        public string Description { get; private set; } = string.Empty;
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public decimal Total { get; private set;  }
        public int InvoiceId { get; private set; }

        public virtual Invoice Invoice { get; private set; }
    }
}
