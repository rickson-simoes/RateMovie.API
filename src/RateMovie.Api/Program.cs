using RateMovie.Api.Filters;
using RateMovie.Application;
using RateMovie.Infraestructure;

namespace RateMovie.Api
{
    public class Program
    {
        public static void Main(string[] args)
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

            // Dependency Injection: Application layer
            builder.Services.DependencyInjectionExtensionApp();

            // Dependency Injection: Infraestructure layer
            builder.Services.DependencyInjectionExtensionInfra(builder.Configuration);


            var app = builder.Build();
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
