using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitControl.Infrastructure.Persistence.Configurations
{
    internal class ClassTypeConfiguration : IEntityTypeConfiguration<ClassType>
    {
        public void Configure(EntityTypeBuilder<ClassType> builder)
        {
            builder.ToTable("ClassTypes");

            builder.HasKey(ct => ct.Id);
            
            builder.Property(ct => ct.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            
            builder.Property(ct => ct.Name).HasMaxLength(100);
            
            builder.Property(ct => ct.Description);

            builder.Property(ct => ct.MaxCapacity);

            builder.Property(ct => ct.DurationMinutes);

            builder.HasMany(ct => ct.Sessions)
                   .WithOne(s => s.ClassType)
                   .HasForeignKey(s => s.ClassTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(ct => new { ct.Id, ct.Name }).IsUnique();
        }
    }
}
