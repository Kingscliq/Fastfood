using FastFood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFood.DB.Configurations;

public class FastFoodConfigurations : IEntityTypeConfiguration<FastFoodModel>{
public void Configure(EntityTypeBuilder<FastFoodModel> builder ) {
    builder.Property(b => b.Name).HasMaxLength(FastFoodModel.MaxNameLength);
    builder.Property(b => b.Description).HasMaxLength(FastFoodModel.MaxDescriptionLength);

    builder.Property(b => b.Savory).HasConversion(
        v => string.Join(',', v), 
        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

    builder.Property(b => b.Sweet).HasConversion(
        v => string.Join(',', v), 
        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
}
}