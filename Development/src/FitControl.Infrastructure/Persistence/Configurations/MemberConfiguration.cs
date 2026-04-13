using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitControl.Infrastructure.Persistence.Configurations
{
    internal class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(m => m.FirstName).HasMaxLength(100);

            builder.Property(m => m.LastName).HasMaxLength(100);

            builder.Property(m => m.DocumentType);

            builder.Property(m => m.DocumentNumber).HasMaxLength(50);

            builder.Property(m => m.Phone).HasMaxLength(20);

            builder.Property(m => m.DateOfBirth);

            builder.Property(m => m.JoinDate);

            builder.Property(m => m.IsActive);

            builder.OwnsOne(m => m.Email, email =>
            {
                email.Property(e => e.Value)
                     .HasColumnName("Email")
                     .HasMaxLength(150)
                     .IsRequired();
            });

            builder.Property(m => m.GymId);

            builder.HasOne(m => m.Gym)
                   .WithMany(g => g.Members)
                   .HasForeignKey(m => m.GymId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.Invoices)
                   .WithOne(i => i.Member)
                   .HasForeignKey(i => i.MemberId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.Bookings)
                   .WithOne(b => b.Member)
                   .HasForeignKey(b => b.MemberId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.Memberships)
                   .WithOne(ms => ms.Member)
                   .HasForeignKey(ms => ms.MemberId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.Attendances)
                   .WithOne(a => a.Member)
                   .HasForeignKey(a => a.MemberId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(m => new { m.Id, m.DocumentNumber }).IsUnique();
        }
    }
}
