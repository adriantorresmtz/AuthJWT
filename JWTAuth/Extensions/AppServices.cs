using JWTAuth.Services;

namespace JWTAuth.Extensions
{
    public static class AppServices
    {
        public static IServiceCollection AddConfig(
             this IServiceCollection services, IConfiguration config)
        {
            services.AddSwaggerGen();
            services.AddEndpointsApiExplorer();
            services.AddSingleton<IUserService, UserService>();
            services.AddCors();
            return services;
        }

        public static void SetServices(this WebApplication app) {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "JWT Auth API");
                c.InjectStylesheet("/swagger/custom.css");
                c.RoutePrefix = String.Empty;
            });
            app.UseCors(options =>
            {
                options
                .AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
        }
    }
}
