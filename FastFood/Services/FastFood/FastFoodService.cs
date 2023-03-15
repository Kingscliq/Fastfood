using FastFood.Models;

namespace FastFood.Services.FastFood;

public class FastFoodService : IFastFoodService
{
    private static readonly Dictionary<Guid, FastFoodModel> _fastfood = new();
    public void CreateFastFood(FastFoodModel fastfood)
    {
        _fastfood.Add(fastfood.Id, fastfood);
    }

    public FastFoodModel GetFastFood(Guid id)
    {
        return _fastfood[id];
    }

    public void UpsertFastFood(FastFoodModel fastfood)
    {
       _fastfood.Add(fastfood.Id, fastfood);
    }
}