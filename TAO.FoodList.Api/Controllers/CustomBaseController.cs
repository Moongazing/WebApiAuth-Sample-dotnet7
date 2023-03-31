using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAO.FoodList.Shared.Dtos;

namespace TAO.FoodList.Api.Controllers
{
  
    public class CustomBaseController : ControllerBase
    {
        public IActionResult ActionResultInstance<T>(Response<T> response) where T : class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        
        
        }
    }
}
