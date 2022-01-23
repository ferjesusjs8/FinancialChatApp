using FinancialChatApp.ChatBot.Application.Interfaces;
using FinancialChatApp.ChatBot.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinancialChatApp.ChatBot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatBotController : ControllerBase
    {
        private readonly IChatBotService _service;
        private readonly ILogger<ChatBotController> _logger;

        public ChatBotController(ILogger<ChatBotController> logger, IChatBotService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult ParseCode([FromBody] CodeMessage codeMessage)
        {
            return Ok(_service.ParseCode(codeMessage.Code, codeMessage.ChatRoom));
        }
    }
}
