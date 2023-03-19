using FastFood.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Persistence;

public class FastFoodDbContext: DbContext{
    public FastFoodDbContext(DbContextOptions<FastFoodDbContext> options) : base(options){
    }
    public DbSet<FastFoodModel> FastFoods {get;set;} = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        // modelBuilder
    }
}