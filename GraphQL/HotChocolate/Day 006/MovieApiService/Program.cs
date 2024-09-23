
using Microsoft.Extensions.DependencyInjection;
using MovieApiService.GraphQl;

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
            builder.Services.AddGraphQLServer().AddQueryType<Query>(); ;
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGraphQL();
            app.MapControllers();
            var serviceProvider = app.Services;
            var moduleInitializer = serviceProvider.GetService<DatabaseInitializer>();
            moduleInitializer?.Initialize().Wait();
            app.Run();
        }
    }
}
