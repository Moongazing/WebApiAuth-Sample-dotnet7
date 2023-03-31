using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.FoodList.Core.Configuration;
using TAO.FoodList.Core.Dtos;
using TAO.FoodList.Core.Entities.Auth;
using TAO.FoodList.Core.Repositories;
using TAO.FoodList.Core.Services;
using TAO.FoodList.Core.UnitOfWork;
using TAO.FoodList.Shared.Dtos;

namespace TAO.FoodList.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly List<Client> _clients;
        private readonly ITokenService _tokenService;
        private readonly UserManager<UserApp> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<UserRefreshToken> _userRefreshTokenService;

        public AuthenticationService(IOptions<List<Client>> optionsClient, ITokenService tokenService, UserManager<UserApp> userManager, IUnitOfWork unitOfWork, IGenericRepository<UserRefreshToken> userRefreshTokenService)
        {
            _clients = optionsClient.Value;
            _tokenService = tokenService;
            _userManager = userManager;
            _userRefreshTokenService = userRefreshTokenService;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if (loginDto==null)
            {
                throw new ArgumentNullException(nameof(loginDto));
            }
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if(user == null)
            {
                return Response<TokenDto>.Fail(400,"Email or Password Wrong!",true);
            }
            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return Response<TokenDto>.Fail(400, "Email or Password Wrong!", true);
            }
            var token = _tokenService.CreateToken(user);
            var userRefreshToken = await _userRefreshTokenService.Where(x => x.UserId == Convert.ToInt32(user.Id)).SingleOrDefaultAsync();
            if (userRefreshToken == null)
            {
                await _userRefreshTokenService.AddAsync(new UserRefreshToken
                {
                    UserId = Convert.ToInt32(user.Id),
                    RefreshToken = token.RefreshToken,
                    Expriration = token.RefreshTokenExpretion
                });
            }
            else
            {
                userRefreshToken.RefreshToken = token.RefreshToken;
                userRefreshToken.Expriration = token.RefreshTokenExpretion;
            }

            await _unitOfWork.CommitAsync();
            return Response<TokenDto>.Success(token, 200);

        }
        public Response<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto)
        {
            var client = _clients.SingleOrDefault(x => x.Id == clientLoginDto.ClientId && x.Secret == clientLoginDto.ClientSecret);
            if (client == null)
            {
                return Response<ClientTokenDto>.Fail(404,"ClientId or ClientSecret not found.",true);
            }

            var token = _tokenService.CreateTokenByClient(client);
            return Response<ClientTokenDto>.Success(token, 200);
        }
        public async Task<Response<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken)
        {
            var isRefreshTokenExists = await _userRefreshTokenService.Where(x => x.RefreshToken == refreshToken).SingleOrDefaultAsync();
            if (isRefreshTokenExists == null)
            {
                return Response<TokenDto>.Fail(404,"Refresh Token Not Found.",true);
            }
            var user = await _userManager.FindByEmailAsync(isRefreshTokenExists.UserId.ToString());
            if (user == null) 
            {
                return Response<TokenDto>.Fail(404, "User Id Not Found.", true);
            }

            var tokenDto = _tokenService.CreateToken(user);
            isRefreshTokenExists.RefreshToken = tokenDto.RefreshToken;
            isRefreshTokenExists.Expriration = tokenDto.RefreshTokenExpretion;

            await _unitOfWork.CommitAsync();

            return Response<TokenDto>.Success(tokenDto, 200);
        }
        public async Task<Response<NoDataDto>> RemoveRefreshTokenAsync(string refreshToken)
        {
            var isRefreshTokenExists = await _userRefreshTokenService.Where(x => x.RefreshToken == refreshToken).SingleOrDefaultAsync();
            if (isRefreshTokenExists == null)
            {
                return Response<NoDataDto>.Fail(404, "Refresh Token Not Found.", true);
            }
            _userRefreshTokenService.Remove(isRefreshTokenExists);

            await _unitOfWork.CommitAsync();

            return Response<NoDataDto>.Success(200);
        }
    }
}
