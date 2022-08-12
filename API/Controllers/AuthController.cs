using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        // Kullanıcı şifre kontrolü
        [HttpGet("VerifyPassword")]
        public IActionResult VerifyPassword(string email, string password)
        {
            var response = _authService.VerifyPassword(email, password);
            return Ok(response);

        }
        // Kullanıcı giriş yapma
        [HttpGet("Login")]
        public IActionResult Login(string email, string password)
        {
            var response = _authService.Login(email, password);
            return Ok(response);

        }
    }
}
