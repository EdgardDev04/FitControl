using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitControl.Infrastructure.Persistence.Configurations
{
    internal class GymConfiguration : IEntityTypeConfiguration<Gym>
    {
        public void Configure(EntityTypeBuilder<Gym> builder)
        {
            builder.ToTable("Gyms");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(g => g.Name).HasMaxLength(100);

            builder.Property(g => g.Phone).HasMaxLength(20);

            builder.OwnsOne(g => g.Email, email =>
            {
                email.Property(e => e.Value)
                     .HasColumnName("Email")
                     .IsRequired()
                     .HasMaxLength(150);
            });

            builder.OwnsOne(g => g.Address, address =>
            {
                address.Property(a => a.Street)
                       .HasMaxLength(200);

                address.Property(a => a.City)
                       .HasMaxLength(100);

                address.Property(a => a.State)
                       .HasMaxLength(100);

                address.Property(a => a.PostalCode)
                       .HasMaxLength(20);

                address.Property(a => a.Country)
                       .HasMaxLength(100);
            });

            builder.HasMany(g => g.ClassSessions)
                   .WithOne(cs => cs.Gym)
                   .HasForeignKey(cs => cs.GymId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(g => g.Members)
                   .WithOne(m => m.Gym)
                   .HasForeignKey(m => m.GymId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(g => g.Trainers)
                   .WithOne(t => t.Gym)
                   .HasForeignKey(t => t.GymId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(g => g.Attendances)
                   .WithOne(a => a.Gym)
                   .HasForeignKey(a => a.GymId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(g => new { g.Id, g.Name }).IsUnique();              

        }
    }
}
