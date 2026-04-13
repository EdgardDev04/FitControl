using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitControl.Infrastructure.Persistence.Context
{
    public class FitControlDbContext : DbContext
    {
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<ClassBooking> ClassBookings { get; set; }
        public DbSet<ClassSession> ClassSessions { get; set; }
        public DbSet<ClassType> ClassTypes { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<MembershipPlan> MembershipPlans { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public FitControlDbContext(DbContextOptions<FitControlDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FitControlDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(300);

            configurationBuilder.Properties<decimal>().HavePrecision(18, 2); 

            configurationBuilder.Properties<DateTime>().HaveColumnType("datetime2");

            configurationBuilder.Properties<Enum>().HaveConversion<string>();

            base.ConfigureConventions(configurationBuilder);
        }
    }
}
