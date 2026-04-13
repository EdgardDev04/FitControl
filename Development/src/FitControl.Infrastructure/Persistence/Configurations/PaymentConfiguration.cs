using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitControl.Infrastructure.Persistence.Configurations
{
    internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(p => p.Amount);

            builder.Property(p => p.PaymentDate);

            builder.Property(p => p.Method);

            builder.Property(p => p.MembershipId);

            builder.Property(p => p.InvoiceId);

            builder.HasOne(p => p.Membership)
                   .WithMany(m => m.Payments)
                   .HasForeignKey(p => p.MembershipId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Invoice)
                   .WithMany(i => i.Payments)
                   .HasForeignKey(p => p.InvoiceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => new { p.Id, p.PaymentDate }).IsUnique();
        }
    }
}