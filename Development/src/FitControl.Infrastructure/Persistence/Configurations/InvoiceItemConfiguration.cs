using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitControl.Infrastructure.Persistence.Configurations
{
    internal class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.ToTable("InvoiceItems");

            builder.HasKey(ii => ii.Id);

            builder.Property(ii => ii.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(ii => ii.Description).HasMaxLength(200);

            builder.Property(ii => ii.ItemType);

            builder.Property(ii => ii.UnitPrice);

            builder.Property(ii => ii.Quantity);

            builder.Property(ii => ii.Total);

            builder.Property(ii => ii.InvoiceId);

            builder.HasOne(ii => ii.Invoice)
                   .WithMany(i => i.InvoiceItems)
                   .HasForeignKey(ii => ii.InvoiceId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(ii => ii.InvoiceId);
        }
    }
}
