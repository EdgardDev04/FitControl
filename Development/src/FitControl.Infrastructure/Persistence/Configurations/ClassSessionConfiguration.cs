using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitControl.Infrastructure.Persistence.Configurations
{
    internal class ClassSessionConfiguration : IEntityTypeConfiguration<ClassSession>
    {
        public void Configure(EntityTypeBuilder<ClassSession> builder)
        {
            builder.ToTable("ClassSessions");

            builder.HasKey(cs => cs.Id);
            
            builder.Property(cs => cs.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            
            builder.Property(cs => cs.StartTime);

            builder.Property(cs => cs.EndTime);

            builder.Property(cs => cs.Capacity);

            builder.Property(cs => cs.Status);

            builder.Property(cs => cs.ClassTypeId);

            builder.Property(cs => cs.TrainerId);

            builder.Property(cs => cs.GymId);

            builder.HasOne(cs => cs.ClassType)
                    .WithMany(ct => ct.Sessions)
                    .HasForeignKey(cs => cs.ClassTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cs => cs.Trainer)
                    .WithMany(t => t.Sessions)
                    .HasForeignKey(cs => cs.TrainerId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cs => cs.Gym)
                  .WithMany(g => g.ClassSessions)
                  .HasForeignKey(cs => cs.GymId)
                  .OnDelete(DeleteBehavior.Restrict);

           builder.HasIndex(cb => new { cb.Id, cb.StartTime, cb.EndTime }).IsUnique();
        }
    }
}
