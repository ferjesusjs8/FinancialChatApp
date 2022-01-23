using FinancialChatApp.Presentation.Models.DTO;
using FinancialChatApp.Presentation.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FinancialChatApp.Presentation.Controllers
{
    public class ChatRoomController : Controller
    {
        private readonly ISendMessageService _service;

        public ChatRoomController(ISendMessageService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Join(string chatRoomDDL)
        {
            if (chatRoomDDL == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("Index");
        }

        public IActionResult SendMessage(string message)
        {
            var model = new MessageDTO()
            {
                Message = message,
                SentDate = DateTime.UtcNow,
                UserName = User.Identity.Name,
            };

            _service.Send(model);

            return View("Index");
        }
    }
}
