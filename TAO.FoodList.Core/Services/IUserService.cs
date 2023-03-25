using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAO.FoodList.Core.Dtos;
using TAO.FoodList.Core.Entities.Auth;
using TAO.FoodList.Shared.Dtos;

namespace TAO.FoodList.Core.Services
{
    public interface IUserService
    {
        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<Response<UserAppDto>> GetUserByName(string userName);
    }
}
