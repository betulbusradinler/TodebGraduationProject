using Business.Abstract;
using Business.Concrete;
using DTO.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // API den BUSSİNESS a ise IUserService i kullanarak gidicez.
        
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(CreateUserRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);

        }
        [HttpPut]
        public IActionResult Put(UpdateUserRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(User user)
        {
            var response = _service.Delete(user);
            return Ok(response);
        }
    }
}
