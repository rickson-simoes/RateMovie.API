using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RateMovie.Api.Contexts;
using RateMovie.Api.Filters;
using RateMovie.Api.Middlewares;
using RateMovie.Api.PackagesConfigurations;
using RateMovie.Application;
using RateMovie.Domain.Security.AccessTokenProvider;
using RateMovie.Infrastructure;
using RateMovie.Infrastructure.Migrations;
using System.Text;

namespace RateMovie.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            // Swagger Auth
            builder.Services.AddSwaggerGen(config =>
            {
                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = @"JWT Authorization Header using Bearer scheme. Example:'Bearer YoUrAw3sOmEjWtT0k3n'",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer",
                    Type = SecuritySchemeType.ApiKey
                });

                config.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                        },
                        new List<string>()
                    }
                });
            });

            //Authentication.JwtBearer Config
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(config =>
            {
                var signingKey = builder.Configuration.GetValue<string>("TokenSettings:JWT:SigningKey")!;

                config.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey))
                };
            });

            // MVC Options: Exception Filter
            builder.Services.AddMvc(options => options.Filters.Add(typeof(RateMovieExceptionFilter)));

            // RateMovie Configs: Json without naming policy.
            builder.Services
                .AddControllers()
                .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);

            // Dependency Injection: Infrastructure layer
            builder.Services.DependencyInjectionExtensionInfra(builder.Configuration);

            // Dependency Injection: Application layer
            builder.Services.DependencyInjectionExtensionApp();

            // Dependency Injection: Context Accessors
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IAccessTokenProvider, AccessTokenProvider>();

            // QuestPDF: Settings
            QuestPdfConfig.QuestPdfSettings();

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                // Migrations/Seeds
                await app.ExecuteDatabaseMigration();
            }

            // Language Middleware
            app.UseMiddleware<LanguageMiddleware>();

            app.UseHttpsRedirection();

            // Auth
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();
        }
    }

    public static class DBMigration
    {
        public static async Task ExecuteDatabaseMigration(this WebApplication app)
        {
            await using var asyncScoped = app.Services.CreateAsyncScope();
            await DatabaseMigration.Execute(asyncScoped.ServiceProvider);
        }
    }
}
