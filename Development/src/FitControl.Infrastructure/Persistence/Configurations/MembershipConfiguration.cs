using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitControl.Infrastructure.Persistence.Configurations
{
    internal class MembershipConfiguration : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(m => m.StartDate);

            builder.Property(m => m.EndDate);

            builder.Property(m => m.Status);

            builder.Property(m => m.IsDeleted);

            builder.Property(m => m.IsAutoRenew);

            builder.Property(m => m.MemberId);

            builder.Property(m => m.MembershipPlanId); 
            
            builder.Property(m => m.PromotionId);

            builder.HasOne(m => m.Member)
                .WithMany(m => m.Memberships)
                .HasForeignKey(m => m.MemberId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(m => m.MembershipPlan)
                .WithMany(mp => mp.Memberships)
                .HasForeignKey(m => m.MembershipPlanId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Promotion)
                .WithMany(p => p.Memberships)
                .HasForeignKey(m => m.PromotionId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(m => m.Payments)
                .WithOne(p => p.Membership)
                .HasForeignKey(p => p.MembershipId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
