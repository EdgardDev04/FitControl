using FitControl.Application.Interfaces.Services;
using FitControl.Application.Mappings;
using FitControl.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FitControl.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MemberProfile>();
                cfg.AddProfile<MembershipPlanProfile>();
                cfg.AddProfile<MembershipProfile>();
            });

            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IMembershipService, MembershipService>();
            services.AddScoped<IMembershipPlanService, MembershipPlanService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
