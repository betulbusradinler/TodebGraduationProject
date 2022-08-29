using Business.Abstract;
using DTO.Chat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
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
        public IActionResult Post(CreateChatRegisterRequest request)
        {
            var response = _chatService.Register(request);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _chatService.GetAll();
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(UpdateChatRequest request)
        {
            var response = _chatService.Update(request);
            return Ok(response);
        }
        [HttpDelete]
        public IActionResult Delete(DeleteChatRequest request)
        {
            var response = _chatService.Delete(request);
            return Ok(response);
        }
    }
}
