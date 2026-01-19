using ArcadeService.BL;
using ArcadeService.DL;
using ArcadeService.Host.Healthchecks;
using ArcadeService.Host.Validators;
using ArcadeService.DL;
using ArcadeService.Host.Healthchecks;
using ArcadeService.Host.Validators;
using FluentValidation;
using Mapster;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace ArcadeService.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Serilog
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .CreateLogger();

            builder.Host.UseSerilog();

            // Dependency Injection
            builder.Services
                .AddDataLayer(builder.Configuration)
                .AddBusinessLayer();

            builder.Services.AddMapster();
            builder.Services.AddValidatorsFromAssemblyContaining<AddArcadeMachineRequestValidator>();
            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Arcade Service",
                    Description = "API for managing and selling arcade machines",
                    Version = "v1"
                });
            });

            builder.Services
                .AddHealthChecks()
                .AddCheck<MyCustomHealthCheck>("custom");

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();
            app.MapHealthChecks("/healthz");

            app.Run();
        }
    }
}
