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

            builder.HasKey(mp => mp.Id);

            builder.Property(mp => mp.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(mp => mp.Name).HasMaxLength(100);

            builder.Property(mp => mp.Description).HasMaxLength(250);

            builder.Property(mp => mp.Price);

            builder.Property(mp => mp.DurationInDays);

            builder.Property(mp => mp.IsActive);

            builder.Property(mp => mp.IsDeleted);

            builder.HasMany(mp => mp.Memberships)
                .WithOne(m => m.MembershipPlan)
                .HasForeignKey(m => m.MembershipPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(mp => mp.Name);
        }
    }
}