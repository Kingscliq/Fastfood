using FastFood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFood.DB.Configurations;

public class FastFoodConfigurations : IEntityTypeConfiguration<FastFoodModel>{



public void Configure(EntityTypeBuilder<FastFoodModel> builder ) {

}
}