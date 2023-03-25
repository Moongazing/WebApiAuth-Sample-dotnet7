using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.FoodList.Core.Configuration;
using TAO.FoodList.Core.Dtos;
using TAO.FoodList.Core.Entities.Auth;

namespace TAO.FoodList.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp userApp);
        ClientTokenDto CreateTokenByClient(Client client);
    }
}
