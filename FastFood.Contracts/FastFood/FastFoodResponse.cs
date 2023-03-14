namespace FastFood.Contracts.FastFood;

public record FastFoodResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime StartDate,
    DateTime EndDate,
    DateTime LastModifiedDateTime,
    List<string> Savory,
    List<string> Sweet
);



