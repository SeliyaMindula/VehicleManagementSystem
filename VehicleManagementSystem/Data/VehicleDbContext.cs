using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VehicleManagementSystem.Models;

public class VehicleDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Vehicle> Vehicles { get; set; }

    public VehicleDbContext(DbContextOptions<VehicleDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure your model (fluent API) here if needed
        // Example:
        // modelBuilder.Entity<Vehicle>().ToTable("Vehicles");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
