using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.FoodList.Core.Dtos
{
    public class TokenDto
    {

        public string AccessToken { get; set; }
        public DateTime AccessTokenExpretion { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpretion { get; set; }

    }
}
