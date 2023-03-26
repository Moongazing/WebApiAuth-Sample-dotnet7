using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.FoodList.Core.Dtos;
using TAO.FoodList.Core.Entities;
using TAO.FoodList.Core.Entities.Auth;

namespace TAO.FoodList.Service.AutoMapper
{
    public class DtoMapper :Profile
    {
        public DtoMapper()
        {
            CreateMap<MainFoodMenuDto, MainFoodMenu>().ReverseMap();
            CreateMap<DietMenuDto, DietFoodMenu>().ReverseMap();
            CreateMap<SaladDto, Salad>().ReverseMap();
            CreateMap<UserAppDto, UserApp>().ReverseMap();

        }
    }
}
