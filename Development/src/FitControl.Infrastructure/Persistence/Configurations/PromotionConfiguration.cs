using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitControl.Infrastructure.Persistence.Configurations
{
    internal class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.ToTable("Promotions");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name);

            builder.Property(p => p.Description);

            builder.Property(p => p.DiscountPercentage);

            builder.Property(p => p.DiscountAmount);

            builder.Property(p => p.FixedPrice);

            builder.Property(p => p.DurationInDays);

            builder.Property(p => p.Status);

            builder.Property(p => p.StartDate);

            builder.Property(p => p.EndDate);

            builder.Property(p => p.IsDeleted);

            builder.HasMany(p => p.Memberships)
                .WithOne(m => m.Promotion)
                .HasForeignKey(m => m.PromotionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => p.Name);
        }
    }
}
