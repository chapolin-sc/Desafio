using Desafio.Api.Context;
using Desafio.Api.Repositories;
using Desafio.Client.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddCors();

var connectionString = builder.Configuration.GetConnectionString("ConnectionMySql");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(
    connectionString, ServerVersion.AutoDetect(connectionString),
            b => b.MigrationsAssembly(typeof(AppDbContext)
                    .Assembly.FullName)));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
