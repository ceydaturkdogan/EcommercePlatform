using ECommercePlatform.Business.Operations.User;
using ECommercePlatform.Business.Operations.User.Dtos;
using ECommercePlatform.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommercePlatform.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }//TODO: ileride action filter olarak kodlanacak. 

            var addUserDto = new AddUserDto
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                Password = request.Password,

            };

            var result =await _userService.AddUser(addUserDto);

            if (result.IsSucceed)
            {
                return Ok();
            }

            else
            {
                return BadRequest(result.Message);
            }

        }
    }
}
