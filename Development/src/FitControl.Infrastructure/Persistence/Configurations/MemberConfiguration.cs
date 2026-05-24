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

            builder.Property(m => m.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(m => m.FirstName);

            builder.Property(m => m.LastName);

            builder.OwnsOne(m => m.Email, email =>
            {
                email.Property(e => e.Value)
                .HasColumnName("Email")
                .HasMaxLength(256);
            });

            builder.Property(m => m.PhoneNumber).HasMaxLength(20);

            builder.Property(m => m.EmergencyContact).HasMaxLength(20);

            builder.Property(m => m.BirthDate);

            builder.Property(m => m.Gender);

            builder.Property(m => m.CreatedAt);

            builder.Property(m => m.IsDeleted);

            builder.Property(m => m.IsActive);

            builder.Property(m => m.UserId);

            builder.HasOne(m => m.User)
                .WithOne(u => u.Member)
                .HasForeignKey<Member>(m => m.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.Attendances)
                .WithOne(a => a.Member)
                .HasForeignKey(m => m.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.Payments)
                .WithOne(a => a.Member)
                .HasForeignKey(m => m.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.Memberships)
                .WithOne(a => a.Member)
                .HasForeignKey(m => m.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(m => m.FirstName);

            builder.HasIndex(m => m.LastName);

        }
    }
}
