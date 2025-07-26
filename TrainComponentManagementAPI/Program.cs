
using Microsoft.EntityFrameworkCore;
using TrainComponentManagementAPI.Handlers;
using TrainComponentManagementAPI.TrainManagmentDB;
using TrainComponentManagementAPI.TrainManagmentWorker;

namespace TrainComponentManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllers();

            // Swagger Services (Swashbuckle)
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Database Context
            builder.Services.AddDbContext<TrainDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Worker Context
            builder.Services.AddScoped<ITrainManagmentService, TrainManagmentService>();
            builder.Services.AddScoped<IPolicyHandler, PolicyHandlerWrapper>();

            var app = builder.Build();

            // Global Error Handling
            app.UseMiddleware<ErrorHandlingMiddleware>();

            // Swagger Middleware (always enabled here; remove dev check if you want it in production too)
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Train Management API v1");
                c.RoutePrefix = string.Empty; // Swagger at root: https://localhost:7204/
            });

            // Other Middleware
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}
