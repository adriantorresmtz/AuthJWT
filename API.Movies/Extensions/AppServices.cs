using API.Movies.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace API.Movies
{
    public static class AppServices
    {
        public static IServiceCollection AddConfig(
             this IServiceCollection services, IConfiguration config)
        {

            services.AddSwaggerGen(options => {

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    new List<string>()
                }
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateActor = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config.GetValue<string>("Jwt:Issuer"),
                    ValidAudience = config.GetValue<string>("Jwt:Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetValue<string>("Jwt:Key")))
                };
            });

            services.AddAuthorization();
            services.AddEndpointsApiExplorer();
            services.AddSingleton<IMovieService, MovieService>();
            services.AddCors();

            return services;
        }

        public static void SetServices(this WebApplication app) {

            app.UseSwagger();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Movie .Net 6 API");
                c.InjectStylesheet("/swagger/custom.css");
                c.RoutePrefix = String.Empty;
            });
            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();

            });

        }
    }
}
