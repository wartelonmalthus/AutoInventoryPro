using AutoInventoryPro.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AutoInventoryPro.Infraestructure.Context;

public class AutoInventoryProDbContext : DbContext
{
    public AutoInventoryProDbContext(DbContextOptions<AutoInventoryProDbContext> options) : base(options)
    {
        
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Dealersh> Dealershes { get; set; }
    public DbSet<Fabricator> Fabricators { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
