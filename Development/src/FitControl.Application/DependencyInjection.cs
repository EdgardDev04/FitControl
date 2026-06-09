using FitControl.Application.Interfaces.Services;
using FitControl.Application.Mappings;
using FitControl.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FitControl.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<AttendanceProfile>();
                cfg.AddProfile<MemberProfile>();
                cfg.AddProfile<MembershipPlanProfile>();
                cfg.AddProfile<MembershipProfile>();
                cfg.AddProfile<PaymentProfile>();
                cfg.AddProfile<PromotionProfile>();
                cfg.AddProfile<UserProfile>(); 
            });

            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IMembershipService, MembershipService>();
            services.AddScoped<IMembershipPlanService, MembershipPlanService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);

            return services;
        }
    }
}
