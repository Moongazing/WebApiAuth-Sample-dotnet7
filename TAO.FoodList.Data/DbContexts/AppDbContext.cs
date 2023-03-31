using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.FoodList.Core.Entities;
using TAO.FoodList.Core.Entities.Auth;

namespace TAO.FoodList.Data.DbContexts
{
    public class AppDbContext:IdentityDbContext<UserApp,IdentityRole,string>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        #region TableProperties
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public DbSet<MainFoodMenu> MainFoodMenus { get; set; }
        public DbSet<DietFoodMenu> DietFoodMenus { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}
