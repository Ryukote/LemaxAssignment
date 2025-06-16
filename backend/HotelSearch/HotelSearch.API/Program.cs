using HotelSearch.API.Middleware;
using HotelSearch.Application;
using HotelSearch.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace HotelSearch.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddProblemDetails();
            builder.Services.AddExceptionHandler<KeyNotFoundExceptionHandler>();
            builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.RegisterServices(builder.Configuration);
            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            //builder.Services.AddDbContext<HotelSearchDbContext>(options => options.UseNpgsql(connectionString), optionsAction => optionsAction.UseNetTopologySuite());
            builder.Services.AddDbContext<HotelSearchDbContext>(options => options.UseNpgsql(connectionString, o => o.UseNetTopologySuite()));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //


            var app = builder.Build();

            app.UseExceptionHandler();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
