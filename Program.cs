using FTELMarket.Data;
using Microsoft.EntityFrameworkCore;

namespace FTELMarket;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        // Register the DbContext: PostgreSQL, connection string read from appsettings.json.
        builder.Services.AddDbContext<FtelMarketContext>(options =>
          options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

        builder.Services.AddCors(options =>
        {
          options.AddPolicy("Front", policy =>
            policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod());
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseCors("Front");

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
