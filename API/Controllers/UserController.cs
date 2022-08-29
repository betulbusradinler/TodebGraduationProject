using API.Configuration.Filters.Auth;
using Business.Abstract;
using DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // API den BUSSİNESS a ise IUserService i kullanarak gidicez.
        
        private readonly IUserService _userService;


        public UserController(IUserService service)
        {
            _userService = service;
        }


        [HttpPost("Register")]
        [Permission(Permission.UserPost)]
        public IActionResult Post(CreateUserRegisterRequest request)
        {
            var response = _userService.Register(request);
            return Ok(response);

        }

        [HttpGet]
        [Permission(Permission.UserGetAll)]
        public IActionResult GetAll()
        {
            var data = _userService.GetAll();
            return Ok(data);
        }

        [HttpPut]
        [Permission(Permission.UserGetPut)]
        public IActionResult Put(UpdateUserRequest request)
        {
            var response = _userService.Update(request);
            return Ok(response);
        }


        [HttpDelete]
        [Permission(Permission.UserDelete)]
        public IActionResult Delete(DeleteUserRequest request)
        {
            var response = _userService.Delete(request);
            return Ok(response);
        }

        //[HttpPatch]
        //public IActionResult Get()
        //{
        //    var data = _userService.GetAll();
        //    return Ok(data);
        //}

    }
}
