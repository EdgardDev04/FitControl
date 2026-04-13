using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitControl.Infrastructure.Persistence.Configurations
{
    internal class MembershipPlanConfiguration : IEntityTypeConfiguration<MembershipPlan>
    {
        public void Configure(EntityTypeBuilder<MembershipPlan> builder)
        {
            builder.ToTable("MembershipPlans");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).UseIdentityColumn().ValueGeneratedOnAdd();


            builder.Property(p => p.Name).HasMaxLength(100);

            builder.Property(p => p.Description);

            builder.Property(p => p.Price);

            builder.Property(p => p.DurationInDays);

            builder.Property(p => p.IsActive);

            builder.HasMany(p => p.Memberships)
                   .WithOne(m => m.Plan)
                   .HasForeignKey(m => m.MembershipPlanId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(p => new { p.Id, p.Name }).IsUnique();
        }
    }
}
