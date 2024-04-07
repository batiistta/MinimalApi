using Carter;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;

namespace MinimalApi.Extensions
{
    public static class Configuration
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddEndpointsApiExplorer()
                .AddCarter()
                .AddDbContext<DataContext>(options =>
                {
                    options.UseInMemoryDatabase("User");
                })
                .AddSwaggerGen();
        }

        public static void RegisterMiddlewares(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger()
                    .UseSwaggerUI();
            }
            app.MapCarter();
        }
    }
}
