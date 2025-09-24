using RateMovie.Api.Filters;
using RateMovie.Api.Middlewares;
using RateMovie.Api.PackagesConfigurations;
using RateMovie.Application;
using RateMovie.Infrastructure;
using RateMovie.Infrastructure.Migrations;

namespace RateMovie.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
