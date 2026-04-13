using Microsoft.EntityFrameworkCore;
using FitControl.Infrastructure.Persistence.Context;

namespace FitControl.WebAPI.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FitControlDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("FitControlConnection")));

            return services;
        }
    }
}