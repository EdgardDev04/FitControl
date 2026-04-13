using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitControl.Infrastructure.Persistence.Configurations
{
    internal class ClassBookingConfiguration : IEntityTypeConfiguration<ClassBooking>
    {
        public void Configure(EntityTypeBuilder<ClassBooking> builder)
        {
            builder.ToTable("ClassBookings");

            builder.HasKey(cb => cb.Id);

            builder.Property(cb => cb.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(cb => cb.BookingDate);
            
            builder.Property(cb => cb.Status);
            
            builder.Property(cb => cb.ClassSessionId);
            
            builder.Property(cb => cb.MemberId);
            
            builder.HasOne(cb => cb.Session)
                    .WithMany(cs => cs.Bookings)
                    .HasForeignKey(cb => cb.ClassSessionId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cb => cb.Member)
                    .WithMany(m => m.Bookings)
                    .HasForeignKey(cb => cb.MemberId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(cb => new { cb.MemberId, cb.ClassSessionId }).IsUnique();
        }
    }
}
