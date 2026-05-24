using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitControl.Infrastructure.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(u => u.UserName);

            builder.Property(u => u.PasswordHash);

            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(e => e.Value)
                .HasColumnName("Email")
                .HasMaxLength(256);
            });

            builder.Property(u => u.IsActive);

            builder.Property(u => u.CreatedAt);

            builder.Property(u => u.UpdatedAt);

            builder.Property(u => u.LastLoginAt);

            builder.HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.Member)
                .WithOne(m => m.User)
                .HasForeignKey<Member>(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(u => u.UserName);
        }
    }
}
