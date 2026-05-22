using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FitControl.Infrastructure.Persistence.Context
{
    public class FitControlDbContext : DbContext
    {
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<MembershipPlan> MembershipPlans { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public FitControlDbContext(DbContextOptions<FitControlDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var foreignKeys = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());

            foreach (var relationship in foreignKeys)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<string>().HaveMaxLength(150);

            configurationBuilder.Properties<decimal>().HavePrecision(18,2);

            configurationBuilder.Properties<DateTime>().HaveColumnType("datetime2");

            configurationBuilder.Properties<DateOnly>().HaveColumnType("datetime2");

            configurationBuilder.Properties<Enum>().HaveConversion<string>();
        }
    }
}
