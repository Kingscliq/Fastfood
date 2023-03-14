namespace FastFood.Models;

public class FastFoodModel{
   public Guid Id {get;}
  public  string? Name {get;}
   public string Description {get;}
   public DateTime StartDate {get;}
   public DateTime EndDate {get;}
   public DateTime LastModifiedDateTime {get;}
   public List<string> Savory {get;}
   public List<string> Sweet {get;}


   public FastFoodModel(Guid Id, string Name, string Description, DateTime StartDate, DateTime EndDate, DateTime LastModifiedDateTime, List<string> Savory, List<string> Sweet){
      this.Id = Id;
      this.Name = Name;
      this.Description = Description;
      this.StartDate = StartDate;
      this.EndDate = EndDate;
      this.LastModifiedDateTime = LastModifiedDateTime;
      this.Savory = Savory;
      this.Sweet = Sweet;
   }

}