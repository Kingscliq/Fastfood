using ErrorOr;
using FastFood.Contracts.FastFood;
using FastFood.ServiceErrors;

namespace FastFood.Models;

public class FastFoodModel
{

    public const int MinNameLength = 3;
    public const int MaxNameLength = 25;
    public const int MinDescriptionLength = 15;
    public const int MaxDescriptionLength = 120;

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public DateTime LastModifiedDateTime { get; private set; }
    public List<string> Savory { get; private set; }
    public List<string> Sweet { get; private set; }

    private FastFoodModel(
       Guid Id,
       string Name,
       string Description,
       DateTime StartDate,
       DateTime EndDate,
       DateTime LastModifiedDateTime,
       List<string> Savory,
       List<string> Sweet)
    {
        this.Id = Id;
        this.Name = Name;
        this.Description = Description;
        this.StartDate = StartDate;
        this.EndDate = EndDate;
        this.LastModifiedDateTime = LastModifiedDateTime;
        this.Savory = Savory;
        this.Sweet = Sweet;
    }

    public static ErrorOr<FastFoodModel> Create(
       string Name,
       string Description,
       DateTime StartDate,
       DateTime EndDate,
       List<string> Savory,
       List<string> Sweet,
       Guid? Id = null
       )
    {
        List<Error> errors = new();

        if (Name.Length is < MinNameLength or > MaxNameLength)
            errors.Add(Errors.FastFood.InvalidName);

        if (Description.Length is < MinDescriptionLength or > MaxDescriptionLength)
            errors.Add(Errors.FastFood.InvalidDescription);

        if (errors.Count > 0)
            return errors;

        return new FastFoodModel(Id ?? Guid.NewGuid(), Name, Description, StartDate, EndDate, DateTime.UtcNow, Savory, Sweet);
    }

    internal static ErrorOr<FastFoodModel> From(CreateFastFoodRequest request)
    {
        return Create(
            request.Name,
            request.Description,
            request.StartDate,
            request.EndDate,
            request.Savory,
            request.Sweet
        );
    }

    internal static ErrorOr<FastFoodModel> From(Guid? Id, UpsertFastFoodResquest request)
    {
        return Create(
              request.Name,
              request.Description,
              request.EndDate,
              request.StartDate,
              request.Savory,
              request.Sweet,
              Id
        );
    }
}