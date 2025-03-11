using Investimento.Api.Configurations;
using Investimento.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using OpenTelemetry.Exporter;
using Prometheus;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

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
            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Investimento API", Version = "v1" });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Insira o token JWT. Ex. Bearer XPTO",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            builder.Services.AddHealthChecks()
               .AddCheck("Health Check", () => HealthCheckResult.Healthy("Service is running"));

            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            var chaveSecreta = jwtSettings["Secret"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(chaveSecreta))
                    };
                });

            builder.Services.AddAuthorization();

            var app = builder.Build();

            app.UseSerilogRequestLogging();
            app.UseMetricServer();
            app.UseHttpMetrics();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
