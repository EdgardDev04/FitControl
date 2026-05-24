using FitControl.Application.Interfaces.Repositories;
using FitControl.Infrastructure.Persistence.Context;
using FitControl.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitControl.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FitControlDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("FitControlConnection")));

            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IMembershipRepository, MembershipRepository>();
            services.AddScoped<IMembershipPlanRepository, MembershipPlanRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
