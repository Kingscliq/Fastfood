
using ErrorOr;
using FastFood.Models;
namespace FastFood.Services.FastFood
{
    public interface IFastFoodService
    {
        void CreateFastFood(FastFoodModel fastfood);
        void DeleteFastFood(Guid id);
        ErrorOr<FastFoodModel> GetFastFood(Guid id);
        void UpsertFastFood(FastFoodModel fastfood);
    }
}