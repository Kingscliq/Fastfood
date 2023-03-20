using ErrorOr;
using FastFood.Models;
using FastFood.DB;
using FastFood.ServiceErrors;

namespace FastFood.Services.FastFood;

public class FastFoodService : IFastFoodService
{
    // private static readonly Dictionary<Guid, FastFoodModel> _fastfood = new();
    private readonly FastFoodDbContext _dbContext;

    public FastFoodService(FastFoodDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public ErrorOr<Created> CreateFastFood(FastFoodModel fastfood)
    {
        _dbContext.Add(fastfood);
        _dbContext.SaveChanges();
        return Result.Created;
    }

    public ErrorOr<Deleted> DeleteFastFood(Guid id)
    {
        var breakfast = _dbContext.FastFoods.Find(id);

        if(breakfast is null){
            return Errors.FastFood.NotFound;
        }

        _dbContext.Remove(breakfast);
        _dbContext.SaveChanges();

        return Result.Deleted;
    }

    public ErrorOr<FastFoodModel> GetFastFood(Guid id)
    {
        var fastFood = _dbContext.FastFoods.Find(id);

        if(fastFood != null && fastFood is FastFoodModel fastFoodModel){
            return fastFoodModel;
        }
        return Errors.FastFood.NotFound;
    }

    public ErrorOr<UpsertedFastFood> UpsertFastFood(FastFoodModel fastfood)
    {
        // var IsNewlyCreated = _dbContext.F÷astFoods.Find(fastfood.Id) == null;
        var IsNewlyCreated = !_dbContext.FastFoods.Any(b => b.Id == fastfood.Id);

        if(IsNewlyCreated){
            _dbContext.Add(fastfood);
        }else{
            _dbContext.Update(fastfood);
        }
        _dbContext.SaveChanges();
        return new UpsertedFastFood(IsNewlyCreated);
    }
}