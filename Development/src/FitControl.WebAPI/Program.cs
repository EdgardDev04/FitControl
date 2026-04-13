
using FitControl.WebAPI.Extensions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FitControl.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

                    options.JsonSerializerOptions.Converters.Add(
                         new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, false)
                     );
                });

            builder.Services.AddDatabase(builder.Configuration);

            builder.Services.AddInfrastructureServices();

            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
