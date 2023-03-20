using FastFood.DB.Configurations;
using FastFood.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFood.DB;

public class FastFoodDbContext: DbContext{
    public FastFoodDbContext(DbContextOptions<FastFoodDbContext> options) : base(options){
    }
    public DbSet<FastFoodModel> FastFoods {get;set;} = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FastFoodConfigurations).Assembly);
    }
}