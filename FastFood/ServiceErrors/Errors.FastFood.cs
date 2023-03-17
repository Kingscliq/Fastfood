using ErrorOr;
using FastFood.Models;
namespace FastFood.ServiceErrors;


public static class Errors{
    public static  class FastFood{
         public static Error InvalidName => Error.NotFound(
            code: "FastFood.InvalidName",
            description: $"Name must be at least {FastFoodModel.MinNameLength} and at most {FastFoodModel.MinNameLength}"
        );
        public static Error InvalidDescription => Error.NotFound(
            code: "FastFood.InvalidDescription",
            description: $"Description must be at least {FastFoodModel.MinDescriptionLength} and at most {FastFoodModel.MinDescriptionLength}"
        );
        public static Error NotFound => Error.NotFound(
            code: "FastFood.NotFound",
            description: "FastFood Not Found"
        );
    }
}
