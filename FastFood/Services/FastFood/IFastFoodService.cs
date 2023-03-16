
using ErrorOr;
using FastFood.Models;
namespace FastFood.Services.FastFood
{
    public interface IFastFoodService
    {
        ErrorOr<Created> CreateFastFood(FastFoodModel fastfood);
        ErrorOr<Deleted> DeleteFastFood(Guid id);
        ErrorOr<FastFoodModel> GetFastFood(Guid id);
        ErrorOr<Updated> UpsertFastFood(FastFoodModel fastfood);
    }
}