using Microsoft.EntityFrameworkCore;

namespace FastFood.Persistence;

public class FastFoodDbContext: DbContext{
    public FastFoodDbContext(DbContextOptions<FastFoodDbContext> options) : base(options){
    }
    public DbSet<FastFoodDbContext> FastFoods {get;set;} = null!;
}