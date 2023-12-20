using Desafio.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Api.Context;

public class AppDbContext : DbContext
{
    public DbSet<CityModel> City { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}