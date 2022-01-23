using FinancialChatApp.Messenger.Application.Interfaces;
using FinancialChatApp.Messenger.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;

namespace FinancialChatApp.Messenger.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessengerController : ControllerBase
    {
        private readonly ILogger<MessengerController> _logger;
        private readonly IMessengerService _service;

        public MessengerController(ILogger<MessengerController> logger, IMessengerService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetMessages()
        {
            _service.GetMessages();

            Thread.Sleep(5000);

            if (MessagesContainer.Messages == null)
            {
                return NotFound();
            }

            // Take the last 50 messages, ordered by date descending
            return Ok(MessagesContainer.Messages.OrderByDescending(m => m.SentDate).TakeLast(50));
        }

        [HttpPost]
        public IActionResult PostMessage([FromBody] MessageDTO message)
        {
            _service.PostMessage(message);

            if (MessagesContainer.Messages == null)
            {
                return Ok(message);
            }

            // Returns the last 50 messages, ordered by date descending
            return Ok(MessagesContainer.Messages.OrderByDescending(m => m.SentDate).TakeLast(50));
        }
    }
}
