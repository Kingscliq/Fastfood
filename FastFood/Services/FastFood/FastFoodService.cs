using ErrorOr;
using FastFood.Models;
using FastFood.ServiceErrors;

namespace FastFood.Services.FastFood;

public class FastFoodService : IFastFoodService
{
    private static readonly Dictionary<Guid, FastFoodModel> _fastfood = new();
    public ErrorOr<Created> CreateFastFood(FastFoodModel fastfood)
    {
        _fastfood.Add(fastfood.Id, fastfood);

        return Result.Created;
    }

    public ErrorOr<Deleted> DeleteFastFood(Guid id)
    {
        _fastfood.Remove(id);

        return Result.Deleted;
    }

    public ErrorOr<FastFoodModel> GetFastFood(Guid id)
    {
        if(_fastfood.TryGetValue(id, out var fastFood)){
             return fastFood;
        }
        return Errors.FastFood.NotFound;
    }

    public ErrorOr<Updated> UpsertFastFood(FastFoodModel fastfood)
    {
       _fastfood[fastfood.Id] = fastfood;

       return Result.Updated;
    }
}