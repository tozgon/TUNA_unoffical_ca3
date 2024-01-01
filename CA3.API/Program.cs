
using CA3.API.DBContext;
using CA3.API.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CA3.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();

			builder.Services.AddDbContext<CustomerDbContext>(opt =>
				opt.UseSqlServer("Server=TunaWindows;Database=CustomerDB;Trusted_Connection=True;TrustServerCertificate=True"));

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Key Auth", Version = "v1" });
				c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
				{
					Description = "ApiKey must appear in header",
					Type = SecuritySchemeType.ApiKey,
					Name = "XApiKey",
					In = ParameterLocation.Header,
					Scheme = "ApiKeyScheme"
				});
				var key = new OpenApiSecurityScheme()
				{
					Reference = new OpenApiReference
					{
						Type = ReferenceType.SecurityScheme,
						Id = "ApiKey"
					},
					In = ParameterLocation.Header
				};
				var requirement = new OpenApiSecurityRequirement
				{
					{ key, new List<string>() }
				};
				c.AddSecurityRequirement(requirement);
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();
			app.UseMiddleware<ApiKeyMiddleware>();
			app.MapControllers();

			app.Run();






			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
			app.UseMiddleware<ApiKeyMiddleware>();
		}
	}
}