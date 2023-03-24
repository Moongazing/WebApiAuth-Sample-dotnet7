using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAO.FoodList.Core.Entities.Auth
{
    public class UserRefreshToken
    {
        public int UserId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expriration { get; set; }
    }
}
