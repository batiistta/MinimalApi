using Carter;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.RateLimit;

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
                .AddSwaggerGen()
                .AddDistributedMemoryCache();
        }

        public static void RegisterMiddlewares(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger()
                    .UseSwaggerUI();
            }
            app.UseMiddleware<RateLimitMiddleware>();
            app.MapCarter();            
        }
    }
}
