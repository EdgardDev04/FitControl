using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitControl.Infrastructure.Persistence.Configurations
{
    internal class MembershipConfiguration : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.ToTable("Memberships");
            
            builder.HasKey(m => m.Id);
            
            builder.Property(m => m.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(m => m.StartDate)
                 .IsRequired();

            builder.Property(m => m.EndDate)
                   .IsRequired();

            builder.Property(m => m.Status);

            builder.Property(m => m.MemberId);

            builder.Property(m => m.MembershipPlanId);

            builder.HasOne(m => m.Member)
                   .WithMany(me => me.Memberships)
                   .HasForeignKey(m => m.MemberId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Plan)
                   .WithMany(p => p.Memberships)
                   .HasForeignKey(m => m.MembershipPlanId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.Payments)
                   .WithOne(p => p.Membership)
                   .HasForeignKey(p => p.MembershipId);

            builder.HasIndex(m => new { m.Id}).IsUnique();
        }
    }
}
