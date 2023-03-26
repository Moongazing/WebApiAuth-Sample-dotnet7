﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.FoodList.Core.Entities;

namespace TAO.FoodList.Core.Dtos
{
    public class MainFoodMenuDto:BaseEntity
    {
        public string Soup { get; set; }
        public decimal SoupCalorie { get; set; }
        public string MainDish { get; set; }
        public decimal MainDishCalorie { get; set; }
        public string OptionalMainDish { get; set; }
        public decimal OptionalMainDishCalorie { get; set; }
        public string SideDish { get; set; }
        public int SideDishCalorie { get; set; }
        public string Dessert { get; set; }
        public int DessertCalorie { get; set; }
        public string SoftDrinks { get; set; }
        public string SoftDrinkCalorie { get; set; }
    }
}
