using API.Configuration.Filters.Auth;
using Business.Abstract;
using DTO.Chat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

    
        [HttpPost]
        [Permission(Permission.ChatPost)]
        public IActionResult Post(CreateChatRegisterRequest request)
        {
            var response = _chatService.Register(request);
            return Ok(response);
        }

        
        [HttpGet]
        [Permission(Permission.ChatGetAll)]
        public IActionResult GetAll()
        {
            var response = _chatService.GetAll();
            return Ok(response);
        }

        [HttpPut]
        [Permission(Permission.ChatGetPut)]
        public IActionResult Update(UpdateChatRequest request)
        {
            var response = _chatService.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        [Permission(Permission.ChatGetPut)]
        public IActionResult Delete(DeleteChatRequest request)
        {
            var response = _chatService.Delete(request);
            return Ok(response);
        }
    }
}
