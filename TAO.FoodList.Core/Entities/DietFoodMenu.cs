using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.FoodList.Core.Entities
{
    public class DietFoodMenu:BaseEntity
    {
        public string DietSoup { get; set; }
        public decimal DietSoupCalorie { get; set; }
        public string DietMainDish { get; set; }
        public decimal DietMainDishCalorie { get; set; }
        public string DietOptionalMainDish { get; set; }
        public decimal DietOptionalMainDishCalorie { get; set; }
        public bool Fruit { get; set; }
        public decimal FruitCalorie { get; set; }
        public bool Yogurt { get; set; }
        public decimal YogurtCalorie { get; set; }
    }
}
