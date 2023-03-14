using FastFood.Models;

namespace FastFood.Services.FastFood;

public class FastFoodService : IFastFoodService
{
    private readonly Dictionary<Guid, FastFoodModel> _fastfood = new();
    public void CreateFastFood(FastFoodModel fastfood)
    {
        _fastfood.Add(fastfood.Id, fastfood );
    }
}