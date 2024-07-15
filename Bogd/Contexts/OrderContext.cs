using Bogd.Models;
using Microsoft.EntityFrameworkCore;

namespace Bogd.Contexts;

public class OrderContext : DbContext
{
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Orderer> Orderers { get; set; } = null!;

    private readonly IConfiguration _configuration;
    
    public OrderContext(IConfiguration configuration)
    
    {
        Database.EnsureCreated();
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("OrderDB"));
    }
}