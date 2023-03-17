using ErrorOr;
using FastFood.ServiceErrors;

namespace FastFood.Models;

public class FastFoodModel
{

    public const int MinNameLength = 3;
    public const int MaxNameLength = 13;
    public const int MinDescriptionLength = 15;
    public const int MaxDescriptionLength = 120;

    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public DateTime LastModifiedDateTime { get; }
    public List<string> Savory { get; }
    public List<string> Sweet { get; }

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

    public ErrorOr<FastFoodModel> Create(
       string Name,
       string Description,
       DateTime StartDate,
       DateTime EndDate,
       List<string> Savory,
       List<string> Sweet)
    {
        if (Name.Length is < MinNameLength or > MaxNameLength)
        {
            return Errors.FastFood.InvalidName;
        }

        if (Description.Length is < MinDescriptionLength or > MaxDescriptionLength)
        {
         return Errors.FastFood.InvalidDescription;
        }

        return new FastFoodModel(Guid.NewGuid(), Name, Description, StartDate, EndDate, DateTime.UtcNow, Savory, Sweet);
    }
}