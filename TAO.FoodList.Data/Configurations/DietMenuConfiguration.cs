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
    public class DietMenuConfiguration : IEntityTypeConfiguration<DietFoodMenu>
    {
        public void Configure(EntityTypeBuilder<DietFoodMenu> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DietSoup).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DietSoupCalorie).IsRequired().HasColumnType("decimal(16,2)");
            builder.Property(x => x.DietMainDish).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DietMainDishCalorie).IsRequired().HasColumnType("decimal(16,2)");
            builder.Property(x => x.DietOptionalMainDish).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DietOptionalMainDishCalorie).IsRequired().HasColumnType("decimal(16,2)");
            builder.Property(x => x.Yogurt).IsRequired().HasMaxLength(200);
            builder.Property(x => x.YogurtCalorie).IsRequired().HasColumnType("decimal(16,2)");
            builder.Property(x => x.Fruit).IsRequired().HasMaxLength(200);
            builder.Property(x => x.FruitCalorie).IsRequired().HasColumnType("decimal(16,2)");

        }
    }
}
