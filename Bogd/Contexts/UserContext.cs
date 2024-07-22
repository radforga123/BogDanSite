using Bogd.Models;
using Microsoft.EntityFrameworkCore;

namespace Bogd.Contexts;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    private readonly IConfiguration _configuration;
    public UserContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("OrderDB"));
    }
}