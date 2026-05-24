using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitControl.Infrastructure.Persistence.Configurations
{
    internal class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.ToTable("Attendances");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(a => a.CheckInTime);

            builder.Property(a => a.CheckOutTime);

            builder.Property(a => a.MemberId).IsRequired();

            builder.HasOne(a => a.Member)
                .WithMany(m => m.Attendances)
                .HasForeignKey(a => a.MemberId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
