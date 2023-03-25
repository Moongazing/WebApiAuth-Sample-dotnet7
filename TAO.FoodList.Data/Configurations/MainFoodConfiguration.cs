using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.FoodList.Core.Entities;

namespace TAO.FoodList.Data.Configurations
{
    public class MainFoodConfiguration : IEntityTypeConfiguration<MainFoodMenu>
    {
        public void Configure(EntityTypeBuilder<MainFoodMenu> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Soup).IsRequired().HasMaxLength(200);
            builder.Property(x => x.SoupCalorie).IsRequired().HasColumnType("decimal(16,2)");
            builder.Property(x => x.MainDish).IsRequired().HasMaxLength(200);
            builder.Property(x => x.MainDishCalorie).IsRequired().HasColumnType("decimal(16,2)");
            builder.Property(x => x.SideDish).IsRequired().HasMaxLength(200);
            builder.Property(x => x.SideDishCalorie).IsRequired().HasColumnType("decimal(16,2)");
            builder.Property(x => x.Dessert).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DessertCalorie).IsRequired().HasColumnType("decimal(16,2)");
            builder.Property(x => x.OptionalMainDish).IsRequired().HasMaxLength(200);
            builder.Property(x => x.OptionalMainDishCalorie).IsRequired().HasColumnType("decimal(16,2)");
            builder.Property(x => x.SoftDrinks).IsRequired().HasMaxLength(200);
            builder.Property(x => x.SoftDrinkCalorie).IsRequired().HasColumnType("decimal(16,2)");

        }
    }
}
