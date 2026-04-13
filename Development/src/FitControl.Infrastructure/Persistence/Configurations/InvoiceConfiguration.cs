using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitControl.Infrastructure.Persistence.Configurations
{
    internal class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(i => i.InvoiceNumber).HasMaxLength(20);

            builder.Property(i => i.IssueDate);

            builder.Property(i => i.SubTotal);

            builder.Property(i => i.Balance);

            builder.Property(i => i.Discount);

            builder.Property(i => i.Tax);

            builder.Property(i => i.TotalAmount);

            builder.Property(i => i.MemberId);

            builder.HasOne(i => i.Member)
                    .WithMany(m => m.Invoices)
                    .HasForeignKey(i => i.MemberId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(i => i.InvoiceItems)
                   .WithOne(ii => ii.Invoice)
                   .HasForeignKey(ii => ii.InvoiceId);

            builder.HasMany(i => i.Payments)
                   .WithOne(p => p.Invoice)
                   .HasForeignKey(p => p.InvoiceId);

            builder.HasIndex(i => new { i.Id, i.InvoiceNumber, i.IssueDate }).IsUnique();
        }
    }
}
