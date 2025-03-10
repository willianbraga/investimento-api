using Investimento.Api.Configurations;
using Investimento.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using OpenTelemetry.Exporter;
using Prometheus;

namespace Investimento
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var seqUrl = builder.Environment.IsDevelopment()
                ? "http://localhost:5341"
                : "http://seq:80";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.Seq(seqUrl)
            .Enrich.FromLogContext()
            .CreateLogger();

            builder.Host.UseSerilog();

            builder.WebHost.UseUrls("http://0.0.0.0:8080");

            builder.Services
                .AddOpenTelemetry()
                .ConfigureResource(resource => resource.AddService("Investimento.Api"))
                .WithTracing(tracing => tracing
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddOtlpExporter(options =>
                    {
                        options.Endpoint = new Uri(seqUrl + "/ingest/otlp/v1/traces");
                        options.Protocol = OtlpExportProtocol.HttpProtobuf;
                    })
                    .AddConsoleExporter()
                );

            var connectionString = builder.Environment.IsDevelopment()
                ? builder.Configuration.GetConnectionString("LocalConnection")
                : builder.Configuration.GetConnectionString("DockerConnection");

            builder.Services.AddDbContext<InvestimentoDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.SetDependencyInjection();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHealthChecks()
               .AddCheck("Health Check", () => HealthCheckResult.Healthy("Service is running"));

            var app = builder.Build();

            app.UseSerilogRequestLogging();
            app.UseMetricServer();
            app.UseHttpMetrics();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
