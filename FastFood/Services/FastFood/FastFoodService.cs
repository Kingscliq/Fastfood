using ErrorOr;
using FastFood.Models;
using FastFood.ServiceErrors;

namespace FastFood.Services.FastFood;

public class FastFoodService : IFastFoodService
{
    private static readonly Dictionary<Guid, FastFoodModel> _fastfood = new();
    public void CreateFastFood(FastFoodModel fastfood)
    {
        _fastfood.Add(fastfood.Id, fastfood);
    }

    public void DeleteFastFood(Guid id)
    {
        _fastfood.Remove(id);
    }

    public ErrorOr<FastFoodModel> GetFastFood(Guid id)
    {
        if(_fastfood.TryGetValue(id, out var fastFood)){
             return fastFood;
        }
        return Errors.FastFood.NotFound;
    }

    public void UpsertFastFood(FastFoodModel fastfood)
    {
       _fastfood[fastfood.Id] = fastfood;
    }
}