using DittoBox.API.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Application.Handlers.Internal;
using DittoBox.API.ContainerManagement.Application.Services;
using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.ContainerManagement.Infrastructure.Repositories;
using DittoBox.API.Shared.Domain.Repositories;
using DittoBox.API.Shared.Infrastructure;
using DittoBox.API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DittoBox.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Configuration.AddUserSecrets<Program>();

            var postgresConnectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");

            if (string.IsNullOrEmpty(postgresConnectionString))
            {
                postgresConnectionString = builder.Configuration.GetConnectionString("POSTGRES_CONNECTION_STRING");
            }
            if (string.IsNullOrEmpty(postgresConnectionString))
            {
                throw new ArgumentException("PostgreSQL connection string is not configured.");
            }

            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(
                    postgresConnectionString
                )
            );

            builder.Services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            RegisterHandlers(builder);
            RegisterRepositories(builder);
            RegisterServices(builder);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();


            // Reset database
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (Environment.GetEnvironmentVariable("RESET_DATABASE") == "true") {
                  db.Database.EnsureDeleted();
                }
                db.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        public static void RegisterHandlers(WebApplicationBuilder builder)
        {
            /* UserProfile handlers */
            builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", corsPolicyBuilder =>
                            {
                corsPolicyBuilder.AllowAnyOrigin()
                                            .AllowAnyMethod()
                                            .AllowAnyHeader();
            });
    }); 
            /* Container Management handlers */
            builder.Services.AddScoped<ICreateContainerCommandHandler, CreateContainerCommandHandler>();
            builder.Services.AddScoped<IGetContainerQueryHandler, GetContainerQueryHandler>();
            builder.Services.AddScoped<IGetContainerStatusByContainerIdQueryHandler, GetContainerStatusByContainerIdQueryHandler>();
            builder.Services.AddScoped<IGetHealthStatusByContainerIdQueryHandler, GetHealthStatusByContainerIdQueryHandler>();
            builder.Services.AddScoped<IUpdateContainerMetricsCommandHandler, UpdateContainerMetricsCommandHandler>();
            builder.Services.AddScoped<IUpdateContainerParametersCommandHandler, UpdateContainerParametersCommandHandler>();
            builder.Services.AddScoped<IUpdateContainerStatusCommandHandler, UpdateContainerStatusCommandHandler>();
            builder.Services.AddScoped<IUpdateHealthStatusCommandHandler, UpdateHealthStatusCommandHandler>();
            builder.Services.AddScoped<IGetContainersQueryHandler, GetContainersQueryHandler>();
            builder.Services.AddScoped<IGetTemplateQueryHandler, GetTemplateQueryHandler>();
            builder.Services.AddScoped<ICreateTemplateCommandHandler, CreateTemplateCommandHandler>();
            builder.Services.AddScoped<IGetTemplatesQueryHandler, GetTemplatesQueryHandler>();
            builder.Services.AddScoped<IAssingTemplateCommandHandler, AssingTemplateCommandHandler>();
            builder.Services.AddScoped<INotificationService, NotificationService>();

           
        }

        public static void RegisterRepositories(WebApplicationBuilder builder)
        {
           
            builder.Services.AddScoped<IContainerRepository, ContainerRepository>();
			      builder.Services.AddScoped<ITemplateRepository, TemplateRepository>();
            builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

        }

        public static void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IContainerService, ContainerService>();
            builder.Services.AddScoped<ITemplateService, TemplateService>();
        }
    }
}
