using System;

namespace FinancialChatApp.ChatBot.Application.Models
{
    public class ChatMessageDTO
    {
        public string ChatRoom { get; set; }
        public string UserName { get; set; }
        public string ChatMessage { get; set; }
        public DateTime SentDate { get; set; }
    }
}
