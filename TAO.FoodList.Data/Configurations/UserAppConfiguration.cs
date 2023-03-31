using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.FoodList.Core.Entities.Auth;

namespace TAO.FoodList.Data.Configurations
{
    public class UserAppConfiguration : IEntityTypeConfiguration<UserApp>
    {
        public void Configure(EntityTypeBuilder<UserApp> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.City).HasMaxLength(50);
        }
    }
}
