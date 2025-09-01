using Restaurants.Api.Middelewares;
using Restaurants.Application.Extention;
using Restaurants.Infrastructure.Extention;
using Restaurants.Infrastructure.Seed;
using Serilog;
using Serilog.Events;

namespace Restaurants
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddScoped<ErrorHandling>();
            builder.Services.AddScoped<RequestTimeLogging>();

            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplication();

            builder.Host.UseSerilog((context, Configuration) =>

            Configuration.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information)
            .WriteTo.Console(outputTemplate: "[{Timestamp:dd-MM HH:mm:ss} {Level:u3}] |{SourceContext}| {NewLine}{Message:lj}{NewLine}{Exception}")

           );

            var app = builder.Build();

            var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
            await seeder.Seed();

            app.UseMiddleware<ErrorHandling>();
            app.UseMiddleware<RequestTimeLogging>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
