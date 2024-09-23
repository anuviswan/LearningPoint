
using Microsoft.Extensions.DependencyInjection;

namespace MovieApiService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("MovieDatabase"));
            builder.Services.AddSingleton<DatabaseInitializer>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            var serviceProvider = app.Services;
            var moduleInitializer = serviceProvider.GetService<DatabaseInitializer>();
            moduleInitializer?.Initialize().Wait();
            app.Run();
        }
    }
}
