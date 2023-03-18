using ErrorOr;
using FastFood.Models;
using FastFood.Persistence;
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
        _fastfood.Remove(id);

        return Result.Deleted;
    }

    public ErrorOr<FastFoodModel> GetFastFood(Guid id)
    {
        if (_fastfood.TryGetValue(id, out var fastFood))
        {
            return fastFood;
        }
        return Errors.FastFood.NotFound;
    }

    public ErrorOr<UpsertedFastFood> UpsertFastFood(FastFoodModel fastfood)
    {
        var IsNewlyCreated = !_fastfood.ContainsKey(fastfood.Id);

        _fastfood[fastfood.Id] = fastfood;

        return new UpsertedFastFood(IsNewlyCreated);
    }
}