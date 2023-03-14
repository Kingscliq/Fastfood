namespace FastFood.Contracts.FastFood;

public record CreateFastFoodRequest(
    string Name,
    string Description,
    DateTime StartDate,
    DateTime EndDate,
    List<string> Savory,
    List<string> Sweet
);