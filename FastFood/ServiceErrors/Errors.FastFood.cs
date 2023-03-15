using ErrorOr;
namespace FastFood.ServiceErrors;

public static class Errors{
    public static  class FastFood{
        public static Error NotFound => Error.NotFound(
            code: "FastFood.NotFound",
            description: "FastFood Not Found"
        );
    }
}
