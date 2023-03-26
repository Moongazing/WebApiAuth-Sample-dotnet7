using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.FoodList.Core.Entities;

namespace TAO.FoodList.Core.Dtos
{
    public class SaladDto:BaseEntity
    {
        public string SaladOption1 { get; set; }
        public string SaladOption2 { get; set; }
        public string SaladOption3 { get; set; }
        public string SaladOption4 { get; set; }
    }
}
