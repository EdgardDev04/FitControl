using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitControl.Infrastructure.Persistence.Configurations
{
    internal class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.ToTable("Trainers");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(t => t.Name).HasMaxLength(100);

            builder.Property(t => t.LastName).HasMaxLength(100);

            builder.Property(t => t.Phone).HasMaxLength(20);

            builder.Property(t => t.Specialty).HasMaxLength(150);

            builder.Property(t => t.Bio);

            builder.Property(t => t.HireDate);

            builder.Property(t => t.Status);

            builder.OwnsOne(t => t.Email, email =>
            {
                email.Property(e => e.Value)
                     .HasColumnName("Email")
                     .HasMaxLength(150)
                     .IsRequired();
            });

            builder.HasOne(t => t.Gym)
                   .WithMany(g => g.Trainers)
                   .HasForeignKey(t => t.GymId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.Sessions)
                   .WithOne(s => s.Trainer)
                   .HasForeignKey(s => s.TrainerId);

            builder.HasIndex(t => new { t.Id, t.Name }).IsUnique();
        }
    }
}
