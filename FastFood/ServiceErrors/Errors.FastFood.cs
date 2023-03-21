using ErrorOr;
using FastFood.Models;
namespace FastFood.ServiceErrors;

public static class Errors{
    public static  class FastFood{
         public static Error InvalidName => Error.Validation(
            code: "InvalidName",
            description: $"Name must be at least {FastFoodModel.MinNameLength} and at most {FastFoodModel.MaxNameLength} characters long"
        );
        public static Error InvalidDescription => Error.Validation(
            code: "InvalidDescription",
            description: $"Description must be at least {FastFoodModel.MinDescriptionLength} and at most {FastFoodModel.MaxDescriptionLength} characters long"
        );
        public static Error NotFound => Error.NotFound(
            code: "NotFound",
            description: "FastFood Not Found"
        );
    }
}
