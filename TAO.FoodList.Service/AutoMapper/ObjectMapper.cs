using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.FoodList.Service.AutoMapper
{
    public static class ObjectMapper
    {
        public static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg => 
            {
                cfg.AddProfile<DtoMapper>();
            });
            return config.CreateMapper();
        });

        public static IMapper Mapper=> lazy.Value;
    }
}
