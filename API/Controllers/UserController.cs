using Business.Abstract;
using DTO.User;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
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
        public IActionResult Post(CreateUserRegisterRequest request)
        {
            var response = _userService.Register(request);
            return Ok(response);

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _userService.GetAll();
            return Ok(data);
        }

        [HttpPut]
        public IActionResult Put(UpdateUserRequest request)
        {
            var response = _userService.Update(request);
            return Ok(response);
        }


        [HttpDelete]
        public IActionResult Delete(DeleteUserRequest request)
        {
            var response = _userService.Delete(request);
            return Ok(response);
        }

        [HttpPatch]
        public IActionResult Get()
        {
            var data = _userService.GetAll();
            return Ok(data);
        }

    }
}
