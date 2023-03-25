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
    public class SaladConfiguration : IEntityTypeConfiguration<Salad>
    {
        public void Configure(EntityTypeBuilder<Salad> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SaladOption1).IsRequired().HasMaxLength(200);
            builder.Property(x => x.SaladOption2).IsRequired().HasMaxLength(200);
            builder.Property(x => x.SaladOption3).IsRequired().HasMaxLength(200);
            builder.Property(x => x.SaladOption4).IsRequired().HasMaxLength(200);
           
        }
    }
}
