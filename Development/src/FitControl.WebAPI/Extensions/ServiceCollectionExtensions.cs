using FitControl.Application.Interfaces;
using FitControl.Application.Mappings;
using FitControl.Domain.Interfaces;
using FitControl.Infrastructure.Repositories;

namespace FitControl.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<AttendanceProfile>();
                cfg.AddProfile<ClassBookingProfile>();
                cfg.AddProfile<ClassSessionProfile>();
                cfg.AddProfile<ClassTypeProfile>();
                cfg.AddProfile<GymProfile>();
                cfg.AddProfile<InvoiceProfile>();
                cfg.AddProfile<MemberProfile>();
                cfg.AddProfile<MembershipProfile>();
                cfg.AddProfile<MembershipPlanProfile>();
                cfg.AddProfile<PaymentProfile>();
                cfg.AddProfile<TrainerProfile>();
            });

            services.Scan(scan => scan
            .FromAssemblyOf<IAttendanceService>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.Scan(scan => scan
            .FromAssemblyOf<UnitOfWork>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            return services;
        }
    }
}
