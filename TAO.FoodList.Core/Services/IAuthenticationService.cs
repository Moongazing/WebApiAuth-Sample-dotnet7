using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.FoodList.Core.Dtos;
using TAO.FoodList.Shared.Dtos;

namespace TAO.FoodList.Core.Services
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDto>>CreateTokenAsync(LoginDto loginDto);
        Response<TokenDto> CreateTokenByRefreshToken(string refreshToken);
        Task<Response<NoDataDto>> RemoveRefreshToken(string refreshToken);
        Task<Response<ClientTokenDto>> CreateTokenByClient(ClientLoginDto clientLoginDto);
    }
}
