using API.Configuration.Filters.Auth;
using Business.Abstract;
using DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserPassword : ControllerBase
    {
        
        private readonly IUserPasswordService _userPassService;


        public UserPassword(IUserPasswordService userPassService)
        {
            _userPassService = userPassService;
        }


     
        [HttpPatch]
        ///[Permission(Permission.UserPasswordPatch)]
        public IActionResult Patch(UpdateUserPasswordRegisterRequest request)
        {
            var data = _userPassService.UpdateUserPassword(request);
            return Ok(data);
        }

    }
}
